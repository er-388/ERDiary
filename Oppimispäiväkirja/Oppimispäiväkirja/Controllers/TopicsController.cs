using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oppimispäiväkirja.Data;
using Oppimispäiväkirja.Models;

namespace Oppimispäiväkirja.Controllers
{
    public class TopicsController : Controller
    {
        private readonly TopicsContext _context;

        public TopicsController(TopicsContext context)
        {
            _context = context;
        }

        // GET: Topics
        public async Task<ViewResult> Index(string hakusana)
        {
            var topics = await _context.Topic.ToListAsync();
            if (!String.IsNullOrEmpty(hakusana))
            {
                topics = topics.Where(topic => topic.Title.Contains(hakusana)).ToList();
            }
            //foreach (Topic topic in topics)
            //{
            //    if (String.IsNullOrEmpty(topic.Description) || String.IsNullOrWhiteSpace(topic.Description))
            //    {
            //        topic.Description = "puuttuva tieto";
            //    }
            //}
            
            return View(topics);
        }


        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Topic.ToListAsync());
        //}

        // GET: Topics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // GET: Topics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Topics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,TimeToMaster,TimeSpent,Source,StartLearningDate,InProgress,CompletionDate")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topic);
        }

        // GET: Topics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }

        // POST: Topics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,TimeToMaster,TimeSpent,Source,StartLearningDate,InProgress,CompletionDate")] Topic topic)
        {
            if (id != topic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(topic.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(topic);
        }

        // GET: Topics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topic = await _context.Topic.FindAsync(id);
            _context.Topic.Remove(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicExists(int id)
        {
            return _context.Topic.Any(e => e.Id == id);
        }


        //POST: Topics/NaytaHakutulos

        //public async Task<IActionResult> NaytaHakutulos(string hakusana)
        //{
        //    return View("Index");
        //    //return View("Index", await _context.Topic.Where(topic => topic.Title.ToLower().Contains(hakusana.ToLower())).ToListAsync());
        //    //return View("Index", await _context.Topic.ToListAsync());

        //}

      

    }
}
