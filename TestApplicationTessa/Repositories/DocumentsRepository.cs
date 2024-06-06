using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TestApplicationTessa.Models;
using TestApplicationTessa.Repositories.Interfaces;
using TestApplicationTessa.Services.Interfaces;

namespace TestApplicationTessa.Services
{
    public class DocumentsRepository : IDocumentsRepository
	{
		private DataBaseContext _dbContext;

		private ITasksRepository _tasksRepository;

		public DocumentsRepository(DataBaseContext dbContext, ITasksRepository tasksRepository)
		{
			_dbContext = dbContext;

			_tasksRepository = tasksRepository;
		}

		public bool CancelActiveTaskOfDocument(int documentId, int activeTaskId)
		{
			try
			{
				var document = _dbContext.Documents.Include(x => x.ActiveTask).FirstOrDefault(doc => doc.Id == documentId);

				if (document != null)
				{
					if (document.ActiveTask != null && document.ActiveTaskId == activeTaskId)
					{
						document.ActiveTask = null;

						document.Status = "Отменен";

						_dbContext.Documents.Update(document);

						_dbContext.SaveChanges();

						return true;
					}
				}

				return false;

			}catch(Exception)
			{
				return false;
			}
		}

		public bool ConfirmActiveTaskOfDocument(int documentId, int activeTaskId)
		{
			try
			{
				var document = _dbContext.Documents.Include(x => x.ActiveTask).FirstOrDefault(doc => doc.Id == documentId);

				if (document != null && document.Status == "В работе")
				{
					var nextTask = _tasksRepository.GetTaskByPreviousTaskId(activeTaskId);

					if (nextTask != null)
					{
						document.ActiveTask = nextTask;
					}
					else
					{
						document.ActiveTask = null;

						document.Status = "В оперативном архиве";
					}

					_dbContext.Documents.Update(document);

					_dbContext.SaveChanges();

					return true;
				}
				else
				{
					return false;
				}

			}catch(Exception)
			{
				return false;
			}
        }

		public bool CreateDocument(DocumentDTOCreate document)
		{
			try
			{
				var newDocument = new Document()
				{
					Status = "В работе",

					Tasks = new List<Models.Task>()
				};

				foreach (var task in document.Tasks)
				{
					newDocument.Tasks.Add(new Models.Task
					{
						Name = task.Name
					});
				}

				for (int i = 1; i < newDocument.Tasks.Count; i++)
				{
					newDocument.Tasks[i].PreviousTask = newDocument.Tasks[i - 1];

					newDocument.Tasks[i].ActiveTaskDocument = null;
				}

				_dbContext.Documents.Add(newDocument);

				_dbContext.SaveChanges();

				newDocument.ActiveTask = newDocument.Tasks[0];

				_dbContext.Documents.Update(newDocument);

				_dbContext.SaveChanges();

				return true;

			}catch(Exception)
			{
				return false;
			}
		}

		public bool DeleteDocument(int documentId)
		{
			try
			{
				var existedDocument = _dbContext.Documents.FirstOrDefault(doc => doc.Id == documentId);

				if (existedDocument != null)
				{
					_dbContext.Documents.Remove(existedDocument);

					_dbContext.SaveChanges();

					return true;
				}
				else
				{
					return false;
				}

			}catch(Exception)
			{
				return false;
			}
	
		}

		public List<DocumentDTOGet> GetAllDocuments()
		{
			try
			{
				var documentsFromDb = _dbContext.Documents.Include(x => x.Tasks).ToList();

				var documentsDTO = new List<DocumentDTOGet>();

				var convertedDoc = new DocumentDTOGet();

				foreach (var doc in documentsFromDb)
				{
					convertedDoc = ConvertDocumentModelToDocumentDTOGet(doc);

					if (convertedDoc != null)
						documentsDTO.Add(convertedDoc);
				}

				return documentsDTO;

			}catch(Exception)
			{
				return new List<DocumentDTOGet>();
			}
		}

		public DocumentDTOGet GetDocumentById(int documentId)
		{
			try
			{
				var documentFromDb = _dbContext.Documents.Include(x => x.Tasks).Include(x => x.ActiveTask).FirstOrDefault(doc => doc.Id == documentId);

				if (documentFromDb != null)
				{
					var documentDto = ConvertDocumentModelToDocumentDTOGet(documentFromDb);

					return documentDto;
				}
				else
				{
					return null;
				}

			}catch(Exception)
			{
				return null;
			}
		}

        private DocumentDTOGet ConvertDocumentModelToDocumentDTOGet(Document doc)
        {
			try
			{
				var documentDto = new DocumentDTOGet
				{
					Id = doc.Id,
					Status = doc.Status,
					Tasks = new List<TaskDTOGet>()
				};

				if (doc.ActiveTask != null)
				{
					documentDto.ActiveTask = new TaskDTOGet
					{
						Id = doc.ActiveTask.Id,
						Name = doc.ActiveTask.Name,
						PreviousTaskId = doc.ActiveTask.PreviousTaskId
					};
				}

				foreach (var task in doc.Tasks)
				{
					if (task.ActiveTaskDocument == null)
					{
						documentDto.Tasks.Add(new TaskDTOGet
						{
							Id = task.Id,
							Name = task.Name,
							PreviousTaskId = task.PreviousTaskId
						});
					}
				}

				return documentDto;

			}catch(Exception)
			{
				return null;
			}
        }
    }
}
