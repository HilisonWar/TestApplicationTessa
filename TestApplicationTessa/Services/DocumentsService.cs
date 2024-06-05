using TestApplicationTessa.Models;
using TestApplicationTessa.Services.Interfaces;

namespace TestApplicationTessa.Services
{
	public class DocumentsService : IDocumentsService
	{
		public bool CreateDocument(Document document)
		{
			return true;
		}

		public bool DeleteDocument(int documentId)
		{
			return true;
		}

		public List<Document> GetAllDocuments()
		{
			return new List<Document>();
		}

		public Document GetDocumentById(int documentId)
		{
			return new Document();
		}

		public void UpdateDocument()
		{
			
		}
	}
}
