using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeImpactApi.Models;
using Neo4jClient;

namespace CodeImpactApi.Queries
{
    public class GetWebpageAffected
    {
        public GraphClient Client { get; private set; }
        public GetWebpageAffected()
        {
            Client = new GraphClient(new Uri("http://neo4j:metead@localhost.:7474/db/data"));
        }

        public List<FileClass> GetFinalNodesAffected(string fullClassName)
        {
            Client.Connect();
            var result = Client.Cypher
                .Match("(fromClass:Class)<-[:REFERENCES*]-(toClass:Class)")
                .Where((FileClass fromClass) => fromClass.FullClassName == fullClassName)
                .AndWhere((FileClass toClass) => toClass.IsWebsiteClas == true)
                .Return(toClass => toClass.As<FileClass>())
                .Results
                .ToList();
            return result;
        }
    }
}