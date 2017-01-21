using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Threading.Tasks;
using SecurityControlAssessment.Model;

namespace SecurityControlAssessment.Data
{
    public static class DocumentDBRepository<T> where T : class
    {
        private static readonly string Endpoint = "https://assessments.documents.azure.com:443/";
        private static readonly string Key = "opXgppmTBUJDjL6VBsFI0792kt8aRzIcVeq9MZkE7QeJR6HBn2VPp3igQTOYzES0O9mgr3d0j3SXGYmvV70y7w==";
        private static readonly string DatabaseId = "assessments";
        private static readonly string CollectionId = "assessmentdetail";
        private static DocumentClient client;

        public static async Task<T> GetItemAsync(string id)
        {
            try
            {
                Document document = await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
                return (T)(dynamic)document;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public static async Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
        {
            IDocumentQuery<T> query = client.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                new FeedOptions { MaxItemCount = -1 })
                .Where(predicate)
                .AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }

        public static async Task<IEnumerable<T>> GetItemsAsync()
        {
            IDocumentQuery<T> query = client.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                new FeedOptions { MaxItemCount = -1 })
                .AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }







        //public static async <IEnumerable<AssessmentAnswer> GetAssessmentAnswers(Guid id)
        //{


        //        IQueryable<Family> familyQuery = this.client.CreateDocumentQuery<Family>(
        //        UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), queryOptions)
        //        .Where(f => f.LastName == "Andersen");
        //IDocumentQuery<T> query = client.CreateDocumentQuery<T>(
        //        UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
        //        new FeedOptions { MaxItemCount = -1 })
        //        .AsDocumentQuery();

        //    List<T> results = new List<T>();
        //    while (query.HasMoreResults)
        //    {
        //        results.AddRange(await query.ExecuteNextAsync<T>());
        //    }

        //    return results;
        //}



        public static async Task<Document> CreateItemAsync(T item)
        {
            return await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), item);
        }

        public static async Task<Document> UpdateItemAsync(string id, T item)
        {
            return await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id), item);
        }

        public static async Task DeleteItemAsync(string id)
        {
            await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
        }

        public static void Initialize()
        {
            client = new DocumentClient(new Uri(Endpoint), Key);
            CreateDatabaseIfNotExistsAsync().Wait();
            CreateCollectionIfNotExistsAsync().Wait();
        }

        private static async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDatabaseAsync(new Database { Id = DatabaseId });
                }
                else
                {
                    throw;
                }
            }
        }

        private static async Task CreateCollectionIfNotExistsAsync()
        {
            try
            {
                await client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseId),
                        new DocumentCollection { Id = CollectionId },
                        new RequestOptions { OfferThroughput = 1000 });
                }
                else
                {
                    throw;
                }
            }
        }
    }
}