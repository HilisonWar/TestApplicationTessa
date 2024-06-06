using TestApplicationTessa.Models;

namespace TestApplicationTessa.Services.Interfaces
{
    public interface IDocumentsRepository
    {
        public bool CreateDocument(DocumentDTOCreate newDocument);

        public DocumentDTOGet GetDocumentById(int documentId);

        public List<DocumentDTOGet> GetAllDocuments();

        public bool DeleteDocument(int documentId);

        public bool CancelActiveTaskOfDocument(int documentId,int taskId);

        public bool ConfirmActiveTaskOfDocument(int documentId,int taskId);

    }
}
