using iTextSharp.text.pdf.parser;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    class StopsGraph
    {
        private Dictionary<string, StopNode> graph = new Dictionary<string, StopNode>();

        public StopsGraph()
        {
            List<string[]> allStops = DBCommunicator.SelectFromStopsById();
            foreach (string[] stop in allStops)
            {
                if (graph.TryGetValue(stop[2] + ", " + stop[1], out StopNode existingNode))
                {
                    existingNode.AddConnectionsToExistingNode(int.Parse(stop[0]));
                }
                else
                {
                    graph.Add(stop[2] + ", " + stop[1], new StopNode(stop));
                }
            }
        }

        public List<Tuple<string, int, int>> Dijkstra(string startStop, string endStop, DateTime connectionStart)
        {
            StopNode curNode;
            if (!graph.TryGetValue(endStop, out curNode)) return null;
            if (!graph.TryGetValue(startStop, out curNode)) return null;
            Dictionary<string, int> globalWeights = new Dictionary<string, int>();
            Dictionary<string, List<Tuple<string, int, int>>> paths = new Dictionary<string, List<Tuple<string, int, int>>>();
            List<string> visitedStops = new List<string>();
            foreach (KeyValuePair<string, StopNode> stopInGraph in graph)
            {
                globalWeights.Add(stopInGraph.Key, int.MaxValue);
                paths.Add(stopInGraph.Key, new List<Tuple<string, int, int>>());
            }
            globalWeights[startStop] = 0;
            while (visitedStops.Count < graph.Count)
            {
                string smallestNotVisited = GetSmallestNotVisited(globalWeights, visitedStops);
                if (smallestNotVisited == null) return null;
                if (smallestNotVisited.Equals(endStop)) return paths[endStop];
                int curWeight;
                int waitTime = 0;
                if (!graph.TryGetValue(smallestNotVisited, out curNode)) return null;
                if (!globalWeights.TryGetValue(smallestNotVisited, out curWeight)) return null;
                foreach (Tuple<string, int, int> connection in curNode.GetConnections())
                {
                    
                    waitTime = calculateWaitTimeAtDateTime(connection.Item3, connectionStart.AddMinutes(globalWeights[smallestNotVisited]));
                    if (waitTime < 0) waitTime = int.MaxValue - (curWeight + connection.Item2);
                    if (globalWeights[connection.Item1] > curWeight + connection.Item2 + waitTime)
                    { 
                        globalWeights[connection.Item1] = curWeight + connection.Item2 + waitTime;
                        paths[connection.Item1] = new List<Tuple<string, int, int>>();
                        paths[connection.Item1].AddRange(paths[curNode.Name]);
                        if (waitTime > 0) paths[connection.Item1].Add(Tuple.Create("wait", waitTime, connection.Item3));
                        paths[connection.Item1].Add(connection);
                    }
                }
                visitedStops.Add(smallestNotVisited);
            }
            return paths[endStop];
        }

        private int calculateWaitTimeAtDateTime(int fromStopOnRoute, DateTime whenArrived)
        {
            List<string[]> prevStops = DBCommunicator.SelectPreviousFromStopsOnRouteById(fromStopOnRoute);
            List<string[]> nextStops = DBCommunicator.SelectNextFromStopsOnRouteById(fromStopOnRoute);
            int arrivalTime = 0;
            foreach (string[] stop in prevStops)
            {
                arrivalTime += int.Parse(stop[4]);
            }
            List<string[]> viableTransits = DBCommunicator.SelectFromTransitsByRouteAndDateTime(whenArrived.AddMinutes(-arrivalTime), int.Parse(prevStops[prevStops.Count - 1][0]), int.Parse(nextStops[nextStops.Count - 1][0]));

            int waitTime = int.MaxValue - (int)whenArrived.TimeOfDay.TotalMinutes;
            if (viableTransits.Count < 1 || viableTransits == null) return -1;
            foreach(string[] transit in viableTransits)
            {
                string[] transitTimeSplit = transit[6].Split(':');
                int transitWaitTime = int.Parse(transitTimeSplit[0]) * 60 + int.Parse(transitTimeSplit[1]) + arrivalTime;
                if (transitWaitTime - (int)whenArrived.TimeOfDay.Minutes < waitTime) waitTime = transitWaitTime - (int)whenArrived.TimeOfDay.TotalMinutes;
            }

            return waitTime;
        }

        private string GetSmallestNotVisited(Dictionary<string, int> weights, List<string> visitedStops)
        {
            int minVal = int.MaxValue;
            string ret = null;
            foreach (KeyValuePair<string, int> weight in weights)
            {
                if (!visitedStops.Contains(weight.Key))
                {
                    if (weight.Value < minVal)
                    {
                        minVal = weight.Value;
                        ret = weight.Key;
                    }
                }
            }
            return ret;
        }
    }
}
