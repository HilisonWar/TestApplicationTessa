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

			if(existDocument == null)
				return NotFound($"Документ с ID {id} не найден");

			else 
				return Ok(existDocument);
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
		public IActionResult EditDocument()
		{
			return Ok();
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

	}
}
