using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using TestApplicationTessa.API_Models;
using TestApplicationTessa.Models;
using TestApplicationTessa.Services.Interfaces;

namespace TestApplicationTessa.Services
{
	public class DocumentsService : IDocumentsService
	{
		private DataBaseContext _dbContext;

		public DocumentsService(DataBaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public bool CancelActiveTaskOfDocument(int documentId, int taskId)
		{
			var document = _dbContext.Documents.FirstOrDefault(doc => doc.Id == documentId);

			if (document != null)
			{
				var activeTask = _dbContext.Tasks.FirstOrDefault(task => task.DocumentId == documentId && task.Id == taskId);

				if (activeTask != null)
				{

					activeTask.IsActiveTask = false;

					document.Status = "Отмена";

					_dbContext.Documents.Update(document);

					_dbContext.Tasks.Update(activeTask);

					_dbContext.SaveChanges();

					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public bool ConfirmActiveTaskOfDocument(int documentId, int activeTaskId)
		{
			var nexTask = _dbContext.Tasks.Include(x => x.PreviousTask).FirstOrDefault(task => task.DocumentId == documentId && task.PreviousTaskId == activeTaskId);

			var document = _dbContext.Documents.FirstOrDefault(doc => doc.Id == documentId);

			if (document != null)
			{
				if (nexTask != null)
				{
					nexTask.PreviousTask.IsActiveTask = false;

					nexTask.IsActiveTask = true;

					_dbContext.Tasks.Update(nexTask);

				}
				else
				{
					var currentTask = _dbContext.Tasks.FirstOrDefault(task => task.Id == activeTaskId);

					if (currentTask != null)
					{
						document.Status = "В оперативном архиве";

						currentTask.IsActiveTask = false;

						_dbContext.Documents.Update(document);

						_dbContext.Tasks.Update(currentTask);
					}
					else
					{
						return false;
					}
				}

				_dbContext.SaveChanges();

				return true;

			}
			else
			{
				return false;
			}
		}

		public bool CreateDocument(Document newDocument)
		{
			newDocument.Status = "В работе";

			newDocument.Tasks[0].IsActiveTask = true;

			for (int i = 1; i < newDocument.Tasks.Count; i++)
			{
				newDocument.Tasks[i].IsActiveTask = false;
				newDocument.Tasks[i].PreviousTask = newDocument.Tasks[i - 1];
			}

			_dbContext.Documents.AddRange(newDocument);

			_dbContext.SaveChanges();

			return true;
		}

		public bool DeleteDocument(int documentId)
		{
			//try
			//{
			//	var existDocument = GetDocumentById(documentId);

			//	if (existDocument != null)
			//	{
			//		_dbContext.Documents.Remove(existDocument);

			//		_dbContext.SaveChanges();

			//		return true;
			//	}
			//	else
			//	{
			//		return false;
			//	}

			//}
			//catch (Exception)
			//{
			//	return false;
			//}

			return true;
		}

		public List<DocumentForm> GetAllDocuments()
		{
			var documentsFromDb = _dbContext.Documents.Include(x => x.Tasks).ToList();

			var documents = new List<DocumentForm>();

			var addedDoc = new DocumentForm();

			foreach (var doc in documentsFromDb)
			{
				addedDoc = new DocumentForm
				{
					ID = doc.Id,
					Status = doc.Status,
					Tasks = new List<TaskForm>()
				};

				foreach (var task in doc.Tasks)
				{
					if (task.IsActiveTask)
					{
						addedDoc.ActiveTask = new TaskForm
						{
							ID = task.Id,
							Name = task.Name,
							PreviousTaskId = null
						};
					}
					else
					{
						addedDoc.Tasks.Add(new TaskForm
						{
							ID = task.Id,
							Name = task.Name,
							PreviousTaskId = task.PreviousTaskId
						});
					}
				}

				documents.Add(addedDoc);

			}
			return documents;
		}


		public DocumentForm GetDocumentById(int documentId)
		{
			var documentFromDb = _dbContext.Documents.Include(x => x.Tasks).FirstOrDefault(doc => doc.Id == documentId);

			var readyDocument = new DocumentForm()
			{
				ID = documentFromDb.Id,
				Status = documentFromDb.Status,
				Tasks = new List<TaskForm>()
			};

			foreach (var task in documentFromDb.Tasks)
			{
				if (task.IsActiveTask)
				{
					readyDocument.ActiveTask = new TaskForm
					{
						ID = task.Id,
						Name = task.Name,
						PreviousTaskId = null
					};
				}
				else
				{
					readyDocument.Tasks.Add(new TaskForm
					{
						ID = task.Id,
						Name = task.Name,
						PreviousTaskId = task.PreviousTaskId
					});
				}
			}



			return readyDocument;
		}


		public bool UpdateDocument(Document editedDocument)
		{
			try
			{
				_dbContext.Documents.Update(editedDocument);

				_dbContext.SaveChanges();

				return true;

			}
			catch (Exception)
			{
				return false;
			}

		}
	}
}
