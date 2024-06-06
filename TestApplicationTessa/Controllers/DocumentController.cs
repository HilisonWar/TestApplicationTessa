using Microsoft.AspNetCore.Mvc;
using TestApplicationTessa.Models;
using TestApplicationTessa.Services.Interfaces;

namespace TestApplicationTessa.Controllers
{
	[Route("api/documents")]
	public class DocumentController : Controller
	{ 
		private IDocumentsRepository _documentsRepository;

		public DocumentController(IDocumentsRepository documentsRepository)
		{
			_documentsRepository = documentsRepository;
		}

		/// <summary>
		/// Получить все существующие документы
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(200,Type=typeof(List<DocumentDTOGet>))]
		public IActionResult GetAllDocuments()
		{
			var allExistDocumentsFromDb = _documentsRepository.GetAllDocuments();

			return Ok(allExistDocumentsFromDb);
		}

		/// <summary>
		/// Получить документ по Id
		/// </summary>
		/// <param name="id">Id документа</param>
		/// <returns></returns>
		[Route("{id:int}")]
		[HttpGet]
        [ProducesResponseType(200, Type = typeof(DocumentDTOGet))]
        public IActionResult GetDocumentById(int id)
		{
			var existDocument = _documentsRepository.GetDocumentById(id);

			if(existDocument != null)
				return Ok(existDocument);

			else
                return NotFound($"Документ с Id {id} не найден");
        }

		/// <summary>
		/// Добавить документ
		/// </summary>
		/// <param name="newDocument"></param>
		/// <returns></returns>
		[HttpPost]
        public IActionResult AddDocument([FromBody] DocumentDTOCreate newDocument)
		{
			if (ModelState.IsValid)
			{
				var result = _documentsRepository.CreateDocument(newDocument);

				if (result)
					return Ok("Документ успешно добавлен");

				else
					return BadRequest("Не удалось добавить документ");
			}
			else
			{
				return BadRequest("Переданы некорректные данные");
			}
		}

		/// <summary>
		/// Удалить документ
		/// </summary>
		/// <param name="id">ID документа</param>
		/// <returns></returns>
		[HttpDelete]
		[Route("{id:int}")]
		public IActionResult DeleteDocument(int id)
		{
			var result = _documentsRepository.DeleteDocument(id);

			if (result)
				return Ok("Документ успешно удален");

			else
				return NotFound($"Документ с Id {id} не найден");
		}

		/// <summary>
		/// Отменить активную задачу документа
		/// </summary>
		/// <param name="documentId">ID документа</param>
		/// <param name="taskId">ID активной задачи, относящейся к документу</param>
		/// <returns></returns>
		[HttpPut]
		[Route("{documentId:int}/task/{taskId:int}/cancel")]
		public IActionResult CancelTaskOfDocument(int documentId,int taskId)
		{
			var resultOfOperation  = _documentsRepository.CancelActiveTaskOfDocument(documentId,taskId);

			if (resultOfOperation)
				return Ok("Задача отменена");

			else 
				return BadRequest("Ошибка отмены задачи");
        }

        /// <summary>
        /// Установить активную задачу как выполненную
        /// </summary>
        /// <param name="documentId">ID документа</param>
        /// <param name="taskId">ID активной задачи, относящейся к документу</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{documentId:int}/task/{taskId:int}/confirm")]
        public IActionResult ConfirmTaskOfDocument(int documentId, int taskId)
        {
            var resultOfOperation = _documentsRepository.ConfirmActiveTaskOfDocument(documentId, taskId);

            if (resultOfOperation)
                return Ok("Задача выполнена");

            else
                return BadRequest("Ошибка выполнения задачи");
        }
    }
}
