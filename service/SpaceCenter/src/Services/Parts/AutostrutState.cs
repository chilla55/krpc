using System;
using KRPC.Service.Attributes;

namespace KRPC.SpaceCenter.Services.Parts
{
    /// <summary>
    /// The state of a radiator. <see cref="RadiatorState"/>
    /// </summary>
    [Serializable]
    [KRPCEnum(Service = "SpaceCenter")]
    public enum AutostrutState
    {
    /// <summary>
    /// Disable autostruts
    /// </summary>
    Off,
    /// <summary>
    /// Add autostruts to the root part
    /// </summary>
    Root,
    /// <summary>
    /// Add autostruts to the heaviest part
    /// </summary>
    Heaviest,
    /// <summary>
    /// Add autostruts to the grandparent part
    /// </summary>
    Grandparent,
    /// <summary>
    /// Require the addition of autostruts to the root part
    /// </summary>
    ForceRoot,
    /// <summary>
    /// Require the addition of autostruts to the heaviest part
    /// </summary>
    ForceHeaviest,
    /// <summary>
    /// Require the addition of autostruts to the grandparent part
    /// </summary>
    ForceGrandparent
  }


}