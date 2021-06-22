using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarzadzanieFlota
{
    class StopNode
    {
        private string name;
        public string Name { get => name; }
        //             nextName|nextTime|fromWhere(alias)
        private List<Tuple<string, int, int>> connections = new List<Tuple<string, int, int>>();

        public StopNode(string[] stopInfo)
        {
            name = stopInfo[2] + ", " + stopInfo[1];
            List<string[]> stopsOnRoute = DBCommunicator.SelectFromStopsOnRouteByStopId(int.Parse(stopInfo[0]));
            if (stopsOnRoute != null)
            {
                if (stopsOnRoute.Count > 0)
                {
                    foreach (string[] stopOnRoute in stopsOnRoute)
                    {
                        if (stopOnRoute[2].Length > 0)
                        {
                            List<string[]> nextHop = DBCommunicator.SelectFromStopsOnRouteById(int.Parse(stopOnRoute[2]));
                            List<string[]> nextHopStop = DBCommunicator.SelectFromStopsById(int.Parse(nextHop[0][1]));
                            connections.Add(Tuple.Create(nextHopStop[0][2] + ", " + nextHopStop[0][1], int.Parse(nextHop[0][5]), int.Parse(stopOnRoute[0])));
                        }
                    }
                }
            }
        }

        public void AddConnectionsToExistingNode(int StopId)
        {
            List<string[]> stopsOnRoute = DBCommunicator.SelectFromStopsOnRouteByStopId(StopId);
            foreach (string[] stopOnRoute in stopsOnRoute)
            {
                if (stopOnRoute[2].Length > 0)
                {
                    List<string[]> nextHop = DBCommunicator.SelectFromStopsOnRouteById(int.Parse(stopOnRoute[2]));
                    List<string[]> nextHopStop = DBCommunicator.SelectFromStopsById(int.Parse(nextHop[0][1]));
                    connections.Add(Tuple.Create(nextHopStop[0][2] + ", " + nextHopStop[0][1], int.Parse(nextHop[0][5]), int.Parse(stopOnRoute[0])));
                }
            }
        }

        public List<Tuple<string, int, int>> GetConnections()
        {
            return connections;
        }
    }
}
