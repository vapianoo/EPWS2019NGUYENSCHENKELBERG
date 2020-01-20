using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[System.Serializable]
public class positional_data
{
    LinkedList<Vector3> positionList = new LinkedList<Vector3>();

    // Positions

    public static Vector3 position_1 = new Vector3(-50f, 6.35f, 17.4f);
    public static Vector3 position_2 = new Vector3(-4f, 6.35f, 16f);
    public static Vector3 position_3 = new Vector3(0f, 6.35f, 12f);
    public static Vector3 position_4 = new Vector3(1.93f, 6.35f, -14.57f);
    public static Vector3 position_5 = new Vector3(17.17f, 6.35f, -15.13f);

    public static Vector3 v_room_2113 = new Vector3(-24.51f, 10.58f, 16.2f);
    public static Vector3 v_room_2203 = new Vector3(-15.73f, 10.58f, -15.2f);
    public static Vector3 v_floor_2_aisle_south = new Vector3(4.6f, 10.58f, 16.2f);
    public static Vector3 v_floor_2_stairs_south_up = new Vector3(14.31f, 10.58f, 13.48f);
    public static Vector3 v_floor_2_stairs_south_up_aisle = new Vector3(14.31f, 10.58f, 16.2f);
    public static Vector3 v_floor_2_stairs_south_down = new Vector3(4.6f, 10.58f, 13.44f);
    public static Vector3 v_floor_2_elevator = new Vector3(4.6f, 10.58f, -10.67f);
    public static Vector3 v_floor_2_aisle_north = new Vector3(4.6f, 10.58f, -15.2f);
    public static Vector3 v_floor_2_stairs_north_up = new Vector3(4.6f, 10.58f, -12.56f);
    public static Vector3 v_floor_2_stairs_north_down = new Vector3(13.96f, 10.58f, -12.56f);
    public static Vector3 v_floor_2_stairs_north_down_aisle = new Vector3(13.96f, 10.58f, -15.2f);

    public graph createGraph()
    {
        graph routeGraph = new graph();
            
        node room_2113 = new node("room_2113", v_room_2113);
        node room_2203 = new node("room_2203", v_room_2203);
        node floor_2_aisle_south = new node("floor_2_aisle_south", v_floor_2_aisle_south);
        node floor_2_stairs_south_up = new node("floor_2_stairs_south_up", v_floor_2_stairs_south_up);
        node floor_2_stairs_south_up_aisle = new node("floor_2_stairs_south_up_aisle", v_floor_2_stairs_south_up_aisle);
        node floor_2_stairs_south_down = new node("floor_2_stairs_south_down", v_floor_2_stairs_south_down);
        node floor_2_elevator = new node("floor_2_elevator", v_floor_2_elevator);
        node floor_2_aisle_north = new node("floor_2_aisle_north", v_floor_2_aisle_north);
        node floor_2_stairs_north_up = new node("floor_2_stairs_north_up", v_floor_2_stairs_north_up);
        node floor_2_stairs_north_down = new node("floor_2_stairs_north_down", v_floor_2_stairs_north_down);
        node floor_2_stairs_north_down_aisle = new node("floor_2_stairs_north_down_aisle", v_floor_2_stairs_north_down_aisle);

        room_2113.addDestination(floor_2_aisle_south, Vector3.Distance(floor_2_aisle_south.position, room_2113.position));

        floor_2_aisle_south.addDestination(room_2113, Vector3.Distance(room_2113.position, floor_2_aisle_south.position));
        floor_2_aisle_south.addDestination(floor_2_stairs_south_up_aisle, Vector3.Distance(floor_2_stairs_south_up_aisle.position, floor_2_aisle_south.position));
        floor_2_aisle_south.addDestination(floor_2_stairs_south_down, Vector3.Distance(floor_2_stairs_south_down.position, floor_2_aisle_south.position));

        floor_2_stairs_south_up_aisle.addDestination(floor_2_aisle_south, Vector3.Distance(floor_2_aisle_south.position, floor_2_stairs_south_up_aisle.position));
        floor_2_stairs_south_up_aisle.addDestination(floor_2_stairs_south_up, Vector3.Distance(floor_2_stairs_south_up.position, floor_2_stairs_south_up_aisle.position));

        floor_2_stairs_south_up.addDestination(floor_2_stairs_south_up_aisle, Vector3.Distance(floor_2_stairs_south_up_aisle.position, floor_2_stairs_south_up.position));

        floor_2_stairs_south_down.addDestination(floor_2_aisle_south, Vector3.Distance(floor_2_aisle_south.position, floor_2_stairs_south_down.position));
        floor_2_stairs_south_down.addDestination(floor_2_elevator, Vector3.Distance(floor_2_elevator.position, floor_2_stairs_south_down.position));

        floor_2_elevator.addDestination(floor_2_stairs_south_down, Vector3.Distance(floor_2_stairs_south_down.position, floor_2_elevator.position));
        floor_2_elevator.addDestination(floor_2_stairs_north_up, Vector3.Distance(floor_2_stairs_north_up.position, floor_2_elevator.position));

        floor_2_stairs_north_up.addDestination(floor_2_elevator, Vector3.Distance(floor_2_elevator.position, floor_2_stairs_north_up.position));
        floor_2_stairs_north_up.addDestination(floor_2_aisle_north, Vector3.Distance(floor_2_aisle_north.position, floor_2_stairs_north_up.position));

        floor_2_aisle_north.addDestination(floor_2_stairs_north_up, Vector3.Distance(floor_2_stairs_north_up.position, floor_2_aisle_north.position));
        floor_2_aisle_north.addDestination(floor_2_stairs_north_down_aisle, Vector3.Distance(floor_2_stairs_north_down_aisle.position, floor_2_aisle_north.position));
        floor_2_aisle_north.addDestination(room_2203, Vector3.Distance(room_2203.position, floor_2_aisle_north.position));

        floor_2_stairs_north_down_aisle.addDestination(floor_2_aisle_north, Vector3.Distance(floor_2_aisle_north.position, floor_2_stairs_north_down_aisle.position));
        floor_2_stairs_north_down_aisle.addDestination(floor_2_stairs_north_down, Vector3.Distance(floor_2_stairs_north_down.position, floor_2_stairs_north_down_aisle.position));

        floor_2_stairs_north_down.addDestination(floor_2_stairs_north_down_aisle, Vector3.Distance(floor_2_stairs_north_down_aisle.position, floor_2_stairs_north_down.position));

        room_2203.addDestination(floor_2_aisle_north, Vector3.Distance(floor_2_aisle_north.position, room_2203.position));

        routeGraph.addNode(room_2113);
        routeGraph.addNode(room_2203);
        routeGraph.addNode(floor_2_aisle_south);
        routeGraph.addNode(floor_2_stairs_south_up);
        routeGraph.addNode(floor_2_stairs_south_up_aisle);
        routeGraph.addNode(floor_2_stairs_south_down);
        routeGraph.addNode(floor_2_elevator);
        routeGraph.addNode(floor_2_aisle_north);
        routeGraph.addNode(floor_2_stairs_north_up);
        routeGraph.addNode(floor_2_stairs_north_down);
        routeGraph.addNode(floor_2_stairs_north_down_aisle);

        return routeGraph;
    }
}
