using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KRPC.Service
{
    /// <summary>
    /// Used to invoke a class method with the KRPCMethod attribute.
    /// Invoke() gets the instance of the class using the guid
    /// (which is always the first parameter) and runs the method.
    /// </summary>
    class ClassMethodHandler : IProcedureHandler
    {
        readonly MethodInfo method;
        readonly IList<ProcedureParameter> parameters;
        readonly ProcedureParameter[] parametersArray;

        public ClassMethodHandler (MethodInfo method)
        {
            this.method = method;
            parameters = method.GetParameters ().Select (x => new ProcedureParameter (x)).ToList ();
            parameters.Insert (0, new ProcedureParameter (typeof(ulong), "this"));
            parametersArray = Parameters.ToArray ();
        }

        /// <summary>
        /// Invokes a method on an object. The first parameter must be an the objects GUID, which is
        /// used to fetch the instance, and the remaining parameters are passed to the method.
        /// </summary>
        public object Invoke (params object[] arguments)
        {
            ulong instanceGuid = (ulong)arguments [0];
            // TODO: should be able to invoke default arguments using Type.Missing, but get "System.ArgumentException : failed to convert parameters"
            var methodArguments = new object[arguments.Length - 1];
            for (int i = 1; i < arguments.Length; i++)
                methodArguments [i - 1] = (arguments [i] == Type.Missing) ? parametersArray [i].DefaultValue : arguments [i];
            return method.Invoke (ObjectStore.Instance.GetInstance (instanceGuid), methodArguments);
        }

        public IEnumerable<ProcedureParameter> Parameters {
            get { return parameters; }
        }

        public Type ReturnType {
            get { return method.ReturnType; }
        }
    }
}

