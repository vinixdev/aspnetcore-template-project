using Bookmarks.Application.Commands;
using Bookmarks.Application.Queries;
using Bookmarks.Domain.Service.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Types;

namespace Bookmarks.Presentation;

[ApiController]
[Route("api/bookmarks")]
public class BookmarksController: ControllerBase
{
   private readonly ISender _sender;
   
   public BookmarksController(ISender sender) => _sender = sender;
   
   [HttpGet]
   public async Task<IActionResult> GetBookmarks()
   {
      var result = await _sender.Send(new GetBookmarksQuery());

      return this.ToActionResult(result);
   }

   [HttpGet("{bookmarkId:guid}", Name = "GetBookmarkById")]
   public async Task<IActionResult> GetBookmark(Guid bookmarkId)
   {
      var result = await _sender.Send(new GetBookmarkQuery(bookmarkId));
      
      return this.ToActionResult(result);
   }

   [HttpPost]
   public async Task<IActionResult> CreateBookmark([FromBody] CreateBookmarkDto dto)
   {
     var result = await _sender.Send(new CreateBookmarkCommand(dto));
     
     return this.ToActionResult(result, rightMapper: (b) => CreatedAtRoute("GetBookmarkById", new { bookmarkId = b.Id }, b));
   }

   [HttpPut("{bookmarkId:guid}")]
   public async Task<IActionResult> UpdateBookmark(Guid bookmarkId, [FromBody] UpdateBookmarkDto dto)
   { 
      var result = await _sender.Send(new UpdateBookmarkCommand(bookmarkId, dto));
      
      return this.ToActionResult(result, rightMapper: (_) => NoContent());
   }

   [HttpDelete("{bookmarkId:guid}")]
   public async Task<IActionResult> DeleteBookmark(Guid bookmarkId)
   {
      await _sender.Send(new DeleteBookmarkCommand(bookmarkId));

      return NoContent();
   }
}