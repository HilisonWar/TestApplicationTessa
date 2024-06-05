using TestApplicationTessa.Models;

namespace TestApplicationTessa.Services.Interfaces
{
    public interface IDocumentsService
    {
        public bool CreateDocument(Document document);

        public void UpdateDocument();

        public Document GetDocumentById(int documentId);

        public List<Document> GetAllDocuments();

        public bool DeleteDocument(int documentId);

    }
}
