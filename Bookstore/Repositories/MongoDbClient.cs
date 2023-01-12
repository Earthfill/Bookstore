using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Interface;
using Bookstore.Model;
using MongoDB.Driver;

namespace Bookstore.Repositories
{
    public class MongoDbClient : IBookServices
    {
        private const string databaseName = "BookstoreDb";
        private const string collectionName = "Books";
        private readonly IMongoCollection<Book> booksCollection;
        // FilterDefinitionVuilder Reference used for GET
        private readonly FilterDefinitionBuilder<Book> filterBuilder = Builders<Book>.Filter;
        public MongoDbClient(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            booksCollection = database.GetCollection<Book>(collectionName);
        }

        public Task CreateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBookAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBooksAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBooksAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}