using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using _5032web12.Models;

namespace _5032web12.Controllers
{
    public class emailsendingsController : Controller
    {
        private Model1 db = new Model1();

        // GET: emailsendings
        public ActionResult Index()
        {
            return View(db.emailsending.ToList());
        }

        // GET: emailsendings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emailsending emailsending = db.emailsending.Find(id);
            if (emailsending == null)
            {
                return HttpNotFound();
            }
            return View(emailsending);
        }

        // GET: emailsendings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: emailsendings/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Subject,Body")] emailsending emailsending, HttpPostedFileBase postedFile)
        {
            MailAddress to = new MailAddress(emailsending.Email);
            MailAddress from = new MailAddress("b29e29fcc2 - afe465@inbox.mailtrap.io");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "test";
            message.Body = "photo";
            var myUniqueFileName = string.Format(@"{0}", Guid.NewGuid());
            if (ModelState.IsValid)
            {
                string serverPath = Server.MapPath("~/Uploads/");
                string fileExtension = Path.GetExtension(postedFile.FileName);
                string filePath = myUniqueFileName + fileExtension;
                string fullPath = serverPath + filePath;
                postedFile.SaveAs(fullPath);

                SmtpClient client = new SmtpClient("smtp.mailtrap.io", 2525)
                {
                    Credentials = new NetworkCredential("d93b02cc045bd7", "6d257a76decd00"),
                    EnableSsl = true
                };
                // code in brackets above needed if authentication required
                var attachment = new System.Net.Mail.Attachment(fullPath);
                message.Attachments.Add(attachment);
                
                try
                {
                    client.Send(message);
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                


            /* db.emailsending.Add(emailsending);
             db.SaveChanges();*/
            //return RedirectToAction("Index");
            }
            ViewBag.Result = "Email has been send.";
            return View(emailsending);
        }

        // GET: emailsendings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emailsending emailsending = db.emailsending.Find(id);
            if (emailsending == null)
            {
                return HttpNotFound();
            }
            return View(emailsending);
        }

        // POST: emailsendings/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,Subject,Body")] emailsending emailsending)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailsending).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emailsending);
        }

        // GET: emailsendings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emailsending emailsending = db.emailsending.Find(id);
            if (emailsending == null)
            {
                return HttpNotFound();
            }
            return View(emailsending);
        }

        // POST: emailsendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            emailsending emailsending = db.emailsending.Find(id);
            db.emailsending.Remove(emailsending);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
