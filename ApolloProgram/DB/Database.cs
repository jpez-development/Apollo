using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaunaDB.Client;
using FaunaDB.Types;
using static FaunaDB.Query.Language;

namespace ApolloProgram.DB
{
    public class Database
    {
        private static string Endpoint;
        private static readonly string DBSecret = "fnAEC1M2TRACAQS4FvXWPSNoC1OqQlJaWz7C5PBi";
        private static FaunaClient client;

        public Database()
        {
            //Connect to the FaunaDB
            Endpoint = "https://db.fauna.com:443";
            client = new FaunaClient(endpoint: Endpoint, secret: DBSecret);
        }

        //Query Database using Index
        public async Task IndexQuery<T>(string index, List<T> list)
        {
            Value query = await client.Query(Paginate(Match(Index(index)))); //Query Index

            //Access data from query
            IResult<Value[]> data = query.At("data").To<Value[]>();
            await data.Match(
                Success: async value => await ProcessData(value, list),
                Failure: async reason => await Task.Run(() => Console.WriteLine($"Something went wrong: {reason}"))
            );
        }

        //Proccess data from Query
        private static async Task ProcessData<T>(Value[] values, List<T> list)
        {
            foreach (Value value in values)
            {
                Value result = await client.Query(Get(value)); //Query Document
                var item = Decoder.Decode<T>(result.At("data"));//Decode Document and generate object containing document data
                list.Add(item);//Add object to List
            }
        }

        //Query Database using ID
        public async Task<T> DocumentQuery<T>(string collection, string id)
        {
            Value query = await client.Query(Get(Ref(Collection(collection), id)));//Query Document
            return Decoder.Decode<T>(query.At("data"));//Decode Document and return generated object containing document data
        }
    }
}
