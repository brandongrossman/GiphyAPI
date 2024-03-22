﻿using Azure.Identity;
using GiphyAPI.Data;
using GiphyAPI.Models;
using GiphyAPI.Models.GiphyAPIResponses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Text.Json.Nodes;

namespace GiphyAPI.Controllers
{
    [Route("ratings")]
    [ApiController]
    public class RatingController : Controller
    {
        private readonly DataContext _context;
        public RatingController(DataContext context)
        { 
            _context = context;
        }


        [HttpGet("gif/{id}")]
        public ActionResult<List<GifRatingAPI>> GetGifRatings(string id)
        {
            //var gifRatings = _context.GifRatings.Where(x => x.GifId == id).ToList();
            //return gifRatings;
            var data = from User in _context.Users
                       from Ratings in _context.GifRatings

                       where (Ratings.GifId == id && User.Id == Ratings.UserId)

                       select new
                       {
                           GifId = Ratings.GifId,
                           Username = User.UserName,
                           Rating = Ratings.Rating
                       };
            GifRatingAPI[] gifRatings = new GifRatingAPI[data.ToList().Count()];
            foreach(var x in data)
            {
                gifRatings.Append(new GifRatingAPI { GifId = x.GifId, Username = x.Username, Rating = x.Rating });
            }
             
            return gifRatings.ToList();
        }

        //// GET: RatingController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: RatingController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: RatingController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: RatingController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: RatingController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: RatingController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}