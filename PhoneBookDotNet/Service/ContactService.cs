using PhoneBookDotNet.Entity;
using PhoneBookDotNet.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookDotNet.Service
{
    public interface IContactService
    {
        public Response Index(string search = null);
        public Response Show(int id);
        public Response Create(ContactDTO dto);
        public Response Update(ContactDTO dto);
        public Response Destroy(int id);

    }
    public class ContactService : IContactService
    {
        private readonly DataContext db;

        public ContactService(DataContext db)
        {
            this.db = db;
        }

        public Response Index(string search = null)
        {
            try
            {

                var query = db.Contacts.AsQueryable();
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search) || x.Phone.Contains(search));
                }
                var contacts = query.Select(contact => new ContactDTO {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Phone = contact.Phone,
                    CreatedAt = contact.CreatedAt
                }).ToList();

                return new Response
                {
                    Data = contacts,
                    Message = "Operação realizada com sucesso"
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    Data = e,
                    Message = e.Message //"Falha ao realizar a operação"
                };
            }


        }
        public Response Show(int id)
        {
            try
            {
                var contact = db.Contacts.Find(id);
                return new Response
                {
                    Data = new ContactDTO
                    {
                        Id = contact.Id,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Phone = contact.Phone,
                        CreatedAt = contact.CreatedAt
                    },
                    Message = "Operação realizada com sucesso"
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    Data = e,
                    Message = e.Message //"Falha ao realizar a operação"
                };
            }


        }
        public Response Create(ContactDTO dto)
        {
            try
            {

                var contact = new Contact
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Phone = dto.Phone,
                    CreatedAt = DateTime.Now
                };
                db.Contacts.Add(contact);
                db.SaveChanges();
                return new Response
                {
                    Data = new ContactDTO
                    {
                        Id = contact.Id,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Phone = contact.Phone,
                        CreatedAt = contact.CreatedAt
                    },
                    Message = "Operação realizada com sucesso"
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    Data = e,
                    Message = e.Message //"Falha ao realizar a operação"
                };
            }
           
         
        }
        public Response Update(ContactDTO dto)
        {
            try
            {
                var contact = db.Contacts.Find(dto.Id);
                contact.FirstName = dto.FirstName;
                contact.LastName = dto.LastName;
                contact.Phone = dto.Phone;
                contact.UpdatedAt = DateTime.Now;
                db.Update(contact);
                db.SaveChanges();
                return new Response
                {
                    Data = dto,
                    Message = "Operação realizada com sucesso"
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    Data = null,
                    Message = e.Message //"Falha ao realizar a operação"
                };
            }


        }
        public Response Destroy(int id)
        {
            try
            {
                var contact = db.Contacts.Find(id);
                db.Remove(contact);
                db.SaveChanges();
                return new Response
                {
                    Data = null,
                    Message = "Operação realizada com sucesso"
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    Data = e,
                    Message = e.Message //"Falha ao realizar a operação"
                };
            }


        }
    }
}
