using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Interface;
using Bookstore.Model;
using MongoDB.Bson;
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

        public async Task CreateBookAsync(Book book)
        {
            await booksCollection.InsertOneAsync(book);
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var filter = filterBuilder.Eq(book => book.Id, id);
            await booksCollection.DeleteOneAsync(filter);
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            var filter = filterBuilder.Eq(book => book.Id, id);
            return await booksCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await booksCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}