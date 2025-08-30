using Bookmarks.Application.Queries;
using Bookmarks.Domain.Service.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
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

   [HttpGet("{bookmarkId}")]
   public async Task<IActionResult> GetBookmark(string bookmarkId)
   {
      var result = await _sender.Send(new GetBookmarkQuery(bookmarkId));
      
      return this.ToActionResult(result);
   }

   [HttpPost]
   public async Task<IActionResult> CreateBookmark([FromBody] CreateBookmarkDto dto)
   {
      throw new NotImplementedException();
   }
}