using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class EventController : Controller
    {
        //Количество строк на странице
        public int pageSize = 4;


        //Репозиторий для работы с БД
        private IEventRepository repository;
        //Интерфейс для отправки кода на почту
        private ISendEmail sendMail;

        public EventController(IEventRepository repo, ISendEmail sendMail) {
            this.repository = repo;
            this.sendMail = sendMail;
        }

        //Отображение всех мероприятий
        public ActionResult Index(int page = 1)
        {
            EventListViewModel model = new EventListViewModel
            {
                Events = repository.Events.OrderBy(ev => ev.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Events.Count()
                }
            };
            return View(model);
        }
        //Отображение информации об одном мероприятии
        public ActionResult Info(int? id) {
            Event getEvent = repository.Events.Where(c=> c.Id == id).FirstOrDefault();// Загружаем событие
            if (getEvent != null)
            {
                getEvent = repository.GetAllEventValue(getEvent);
                return View(getEvent);
            }
            else {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult CreateEvent() {
            return View(new Event());
        }
        
        [HttpPost]
        public ActionResult CreateEvent(Event Event) {
            if (ModelState.IsValid)
            {
                repository.SaveEvent(Event);
                TempData["message"] = string.Format("Мероприятие \"{0}\" было добавлено", Event.Name);
                return RedirectToAction("Index");
            }
            else {
                return View(Event);
            }
        }
        [HttpGet]
        public ActionResult RegisterOnEvent(int id) {
            Event getEvent = repository.Events.Where(c => c.Id == id).FirstOrDefault();// Загружаем событие
            if (getEvent != null) {
                return View(new RegisterOnEvent { EventId = id});
            }
            return HttpNotFound();
        }


        [HttpPost]
        public ActionResult RegisterOnEvent(RegisterOnEvent model) {
            if (ModelState.IsValid) {
                var getUser = repository.RegisterInEvent.Where(m => m.Email == model.Email).Where(m=>m.EventId == model.EventId).FirstOrDefault();
                if (getUser == null)
                {
                    RegisterOnEvent user = new RegisterOnEvent
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        EmailConfirmed = false,
                        EventId = model.EventId,
                        Token = model.Email.GetHashCode().ToString() + model.EventId, //генерируем ссылку посредством хеш кода почты и добавляем Ид события
                    };
                    bool result = repository.SaveRegisterUser(user);

                    if (result)
                    {
                        string emailText = string.Format("Для завершения регистрации перейдите по ссылке:" +
                            "<a href=\"{0}\" title=\"Подтвердить регистрацию\">{0}</a>",
                            Url.Action("ConfirmEmail", "Event", new { Token = user.Token, Email = user.Email }, Request.Url.Scheme));

                        sendMail.SendMail(user.Email, string.Format("{0} {1}, подтвердите ваше участие в мероприятии", model.FirstName, model.LastName), emailText);
                        TempData["message"] = string.Format("{0} {1}, для подтверждении регистрации на мероприятие, подтвердите сообщение в почтовом ящике: {2}",model.FirstName, model.LastName, model.Email);
                        return RedirectToAction("Index");
                    }
                }
                else if (getUser.EmailConfirmed == false)
                {
                    ModelState.AddModelError("", "Вы уже регистрировались на это мероприятие, проверьте почту и подтвердите");
                    return View();
                }
                else {
                    ModelState.AddModelError("", "Вы уже в списке приглашенных");
                    return View();
                }
            }
            return View();

        }

        public ActionResult ConfirmEmail(string Token, string Email) {
            RegisterOnEvent user = repository.RegisterInEvent.Where(m => m.Token == Token).FirstOrDefault();
            if (user != null) {
                if (user.Email == Email) {
                    repository.SaveConfirmedEmail(user);
                    TempData["message"] = string.Format("Вы успешно подтвердили свою регистрацию на мероприятие: {0} {1}",user.FirstName,user.LastName);
                    return RedirectToAction("Index");
                }
                TempData["message"] = string.Format("Произошла ошибка");
                return RedirectToAction("Index");
            }
            TempData["message"] = string.Format("Произошла ошибка");
            return RedirectToAction("Index");
        }
    }

}