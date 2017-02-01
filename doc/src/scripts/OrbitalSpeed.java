import krpc.client.Connection;
import krpc.client.RPCException;
import krpc.client.services.SpaceCenter;
import krpc.client.services.SpaceCenter.ReferenceFrame;
import krpc.client.services.SpaceCenter.Vessel;

import org.javatuples.Triplet;

import java.io.IOException;

public class OrbitalSpeed {
    public static void main(String[] args)
        throws IOException, RPCException, InterruptedException {
        Connection connection = Connection.newInstance("Orbital speed");
        SpaceCenter spaceCenter = SpaceCenter.newInstance(connection);
        Vessel vessel = spaceCenter.getActiveVessel();
        ReferenceFrame refFrame =
            vessel.getOrbit().getBody().getNonRotatingReferenceFrame();

        while (true) {
            Triplet<Double,Double,Double> velocity =
                vessel.flight(refFrame).getVelocity();
            System.out.println("Orbital velocity = (" +
                               velocity.getValue0() + "," +
                               velocity.getValue1() + "," +
                               velocity.getValue2() + ")");

            double speed = vessel.flight(refFrame).getSpeed();
            System.out.println("Orbital speed = " + speed + " m/s");

            Thread.sleep(1000);
        }
    }
}
