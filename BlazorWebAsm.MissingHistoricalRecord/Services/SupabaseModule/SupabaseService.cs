using Postgrest;
using Postgrest.Models;
using System.Linq.Expressions;
using System.Reflection;
using Websocket.Client;
using static Postgrest.QueryOptions;

namespace BlazorWebAsm.MissingHistoricalRecord.Services.SupabaseModule
{
    public class SupabaseService
    {
        private Supabase.Client SupabaseConnection = null;

        public SupabaseService()
        {
            CreateSupabaseConnection();
        }

        private void CreateSupabaseConnection()
        {
            var url = "https://crgqlesdpsewzxodgsll.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNyZ3FsZXNkcHNld3p4b2Rnc2xsIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTY5MTUwNjI3OCwiZXhwIjoyMDA3MDgyMjc4fQ.qprthozo7DOwF_RxRgUEbJdwaGDIU_Nf9WW5YeLR7xk";

            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };
            try
            {
                if(SupabaseConnection == null)
                {
                    SupabaseConnection = new Supabase.Client(url, key, options);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<T?> GetAsync<T>(
          Expression<Func<T, object[]>> predicate,
          Expression<Func<T, bool>> wherePredicate)
          where T : BaseModel, new()
        {
            var result = await SupabaseConnection
              .From<T>()
              .Select(predicate)
              .Where(wherePredicate)
              .Get();

            return result.Model;
        }

        public async Task<List<T>> GetListAsync<T>(
       Expression<Func<T, object[]>> predicate,
       Expression<Func<T, bool>> wherePredicate)
       where T : BaseModel, new()
        {
            var result = await SupabaseConnection
              .From<T>()
              .Select(predicate)
              .Where(wherePredicate)
              .Get();

            return result.Models;
        }


        public async Task<T?> InsertAsync<T>(T data)
            where T : BaseModel, new()
        {
            var response = await SupabaseConnection
                 .From<T>()
                 .Insert(data);
            return response.Model;
        }

        public async Task<List<T>> InsertList<T>(List<T> dataList)
            where T : BaseModel, new()
        {
            var response = await SupabaseConnection
                .From<T>()
                .Insert(
                    dataList,
                    new QueryOptions { Returning = ReturnType.Representation }
                    );

            return response.Models;
        }

        public async Task<bool> UpdateAsync<T>(T data)
             where T : BaseModel, new()
        {
            var response = await data.Update<T>();
            return response.ResponseMessage != null;
        }

    }
}
