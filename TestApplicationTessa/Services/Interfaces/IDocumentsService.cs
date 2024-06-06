using TestApplicationTessa.API_Models;
using TestApplicationTessa.Models;

namespace TestApplicationTessa.Services.Interfaces
{
    public interface IDocumentsService
    {
        public bool CreateDocument(Document newDocument);

        public bool UpdateDocument(Document editedDocument);

        public DocumentForm GetDocumentById(int documentId);

        public List<DocumentForm> GetAllDocuments();

        public bool DeleteDocument(int documentId);

        public bool CancelActiveTaskOfDocument(int documentId,int taskId);

        public bool ConfirmActiveTaskOfDocument(int documentId,int taskId);

    }
}
