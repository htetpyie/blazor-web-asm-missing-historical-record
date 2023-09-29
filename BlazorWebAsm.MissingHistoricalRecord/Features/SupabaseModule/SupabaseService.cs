using Postgrest;
using Postgrest.Models;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.VisualBasic.FileIO;
using Websocket.Client;
using static Postgrest.QueryOptions;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.SupabaseModule
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
            var key =
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNyZ3FsZXNkcHNld3p4b2Rnc2xsIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTY5MTUwNjI3OCwiZXhwIjoyMDA3MDgyMjc4fQ.qprthozo7DOwF_RxRgUEbJdwaGDIU_Nf9WW5YeLR7xk";

            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };
            try
            {
                if (SupabaseConnection == null)
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

        public async Task<T?> GetAsync<T>(
            Expression<Func<T, bool>> wherePredicate)
            where T : BaseModel, new()
        {
            var result = await SupabaseConnection
                .From<T>()
                .Where(wherePredicate)
                .Get();

            return result.Model;
        }

        public async Task<List<T>> GetAllAsync<T>(
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

        public async Task<List<T>> GetAllAsync<T>()
            where T : BaseModel, new()
        {
            var result = await SupabaseConnection
                .From<T>()
                .Get();

            return result.Models;
        }

        public async Task<List<T>> GetAllAsync<T>(
            Expression<Func<T, bool>> wherePredicate)
            where T : BaseModel, new()
        {
            var result = await SupabaseConnection
                .From<T>()
                .Where(wherePredicate)
                .Get();

            return result.Models;
        }


        //Method for limit
        public async Task<List<T>> GetListWithLimitAsync<T>(
            Expression<Func<T, bool>> wherePredicate,
            int from, int to)
            where T : BaseModel, new()
        {
            try
            {
                var result = await SupabaseConnection
                    .From<T>()
                    .Where(wherePredicate)
                    .Range(from, to)
                    .Get();
                return result.Models;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<T>> GetListByPaginationAsync<T>(
            Expression<Func<T, bool>> wherePredicate,
            int pageNo = 1, int pageSize = 10)
            where T : BaseModel, new()
        {
            int from = (pageNo - 1) * pageSize;
            int to = from + pageSize - 1;
            try
            {
                var result = await SupabaseConnection
                    .From<T>()
                    .Where(wherePredicate)
                    .Range(from, to)
                    .Get();
                return result.Models;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<T>> GetListByIndexAsync<T>(
            Expression<Func<T, bool>> wherePredicate,
            int startIndex = 1, int pageSize = 10)
            where T : BaseModel, new()
        {
           
            try
            {
                int to = startIndex + pageSize -1 ;
                var result = await SupabaseConnection
                    .From<T>()
                    .Where(wherePredicate)
                    .Range(startIndex, to)
                    .Get();
                return result.Models;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<T>> GetLatestListAsync<T>(
            Expression<Func<T, bool>> wherePredicate,
            Expression<Func<T, object>> Orderbypredicate,
            Constants.Ordering ordering,
            int pageSize = 10)
            where T : BaseModel, new()
        {
            var result = await SupabaseConnection
                .From<T>()
                .Where(wherePredicate)
                .Order(Orderbypredicate, ordering)
                .Limit(pageSize)
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

        public async Task<int> CountAsync<T>(
            Expression<Func<T, bool>> wherePredicate
        ) where T : BaseModel, new()
        {
            var count = await SupabaseConnection
                .From<T>()
                .Where(wherePredicate)
                .Count(Constants.CountType.Exact);
            return count;
        }

        public async Task RemoveAsync<T>(Expression<Func<T, bool>> predicate)
            where T : BaseModel, new()
        {
            await SupabaseConnection
                .From<T>()
                .Where(predicate)
                .Delete();
        }
    }
}