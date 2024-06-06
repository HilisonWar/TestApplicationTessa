using Microsoft.AspNetCore.Mvc;
using TestApplicationTessa.Models;
using TestApplicationTessa.Services.Interfaces;

namespace TestApplicationTessa.Controllers
{
	[Route("api/documents")]
	public class DocumentController : Controller
	{ 
		private IDocumentsService _documentsService;

		public DocumentController(IDocumentsService documentsService)
		{
			_documentsService = documentsService;
		}
		
		[HttpGet]
		public IActionResult GetAllDocuments()
		{
			var allExistDocumentsFromDb = _documentsService.GetAllDocuments();

			return Ok(allExistDocumentsFromDb);
		}

		[Route("{id}")]
		[HttpGet]
		public IActionResult GetDocumentById(int id)
		{
			var existDocument = _documentsService.GetDocumentById(id);

			if(existDocument != null)
				return Ok(existDocument);

			else
                return NotFound($"Документ с ID {id} не найден");
        }

		[HttpPost]
		public IActionResult AddDocument([FromBody] Document newDocument)
		{
			var result = _documentsService.CreateDocument(newDocument);

			if (result)
				return Ok("Документ успешно добавлен");

			else
				return BadRequest("Не удалось добавить документ");
		}

		[HttpPut]
		public IActionResult EditDocument([FromBody] Document editedDocument)
		{
			var resultOfOperation = _documentsService.UpdateDocument(editedDocument);

			if (resultOfOperation)
				return Ok("Документ успешно обновлен");

            else
                return BadRequest("Не удалось обновить документ");
        }

		[HttpDelete]
		[Route("{id}")]
		public IActionResult DeleteDocument(int id)
		{
			var result = _documentsService.DeleteDocument(id);

			if (result)
				return Ok("Документ успешно удален");

			else
				return BadRequest($"Не удалось удалить документ с ID {id}");
		}

		[HttpPut]
		[Route("{documentId}/task/{taskId}/cancel")]
		public IActionResult CancelTaskOfDocument(int documentId,int taskId)
		{
			var resultOfOperation  = _documentsService.CancelActiveTaskOfDocument(documentId,taskId);

			if (resultOfOperation)
				return Ok("Задача отменена");

			else 
				return BadRequest("Возникла ошибка при отмене задачи");
        }

        [HttpPut]
        [Route("{documentId}/task/{taskId}/confirm")]
        public IActionResult ConfirmTaskOfDocument(int documentId, int taskId)
        {
            var resultOfOperation = _documentsService.ConfirmActiveTaskOfDocument(documentId, taskId);

            if (resultOfOperation)
                return Ok("Задача выполнена");

            else
                return BadRequest("Возникла ошибка при выполнении задачи");
        }

    }
}
