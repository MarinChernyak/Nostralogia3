using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.Utilities;
using Nostralogia3.Utilities;
using NostralogiaDAL.NostradamusEntities;
using NostralogiaDAL.SMGeneralEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Nostralogia3.Models.Authentication
{
    public class MUser : MUserBase
    {
        [DisplayName("Enter Email")]
        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [DisplayName("Email")]
        public short? CountryId { get; set; }
        [DisplayName("State/Province/Land (Optional)")]
        public int? StateId { get; set; }
        [DisplayName("City/Town (Optional)")]
        public int? PlaceId { get; set; }
        [DisplayName("First Name (Optional)")]
        public string  FirstName { get; set; }
        [DisplayName("Last Name (Optional)")]
        public string LastName { get; set; }
        [DisplayName("Midle Name (Optional)")]
        public string MidleName { get; set; }
        [DisplayName("Gender (Optional)")]
        public short? Sex { get; set; }
        [DisplayName("Date of Birth (Optional)")]
        public DateTime Dob { get; set; }
        public string ErrorMessage { get; set; }

        public DateTime ActivationDate { get; set; }


        public List<SelectListItem> SexCollection { get; protected set; }
        public MUser()
        {
            FillUpSexCollection();
            UpdateDates();
        }
        protected void FillUpSexCollection()
        {
            using(NostradamusContext context = new NostradamusContext())
            {
                SexCollection = new List<SelectListItem>();
                List<SexDatum> lst = context.SexData.ToList();
                foreach(SexDatum sd in lst)
                {
                    SexCollection.Add(new SelectListItem()
                    {
                        Text = sd.SexDescription,
                        Value = sd.SexId.ToString(),
                        Selected = sd.SexId == 3 ? true : false
                    });
                }
            }
        }

        public bool ResetPassword()
        {
            bool bIsOK = false;

            if (!string.IsNullOrEmpty(UserName))
            {
                using (SMGeneralContext _context = new SMGeneralContext())
                {
                    SecurityProtocol prot = _context.SecurityProtocols.FirstOrDefault(x => x.UserName == UserName);
                    EncryptDataUpdater datapdater = new EncryptDataUpdater();
                    MUser muser = datapdater.GetDecryptedUser(UserName);
                    if (!string.IsNullOrEmpty(muser.Email))
                    {
                        StringGenerator gen = new StringGenerator(8, true, false, true, true);
                        string newPass = gen.GenericString;
                        muser.Password = newPass;

                        try
                        {
                            StringBuilder body = new StringBuilder();
                            body.AppendLine("<h1>Nostralogia informs you</h1>");
                            body.AppendLine($"<p>Currently your password is - {newPass} </p>");
                            using (MailMessage msg = new MailMessage())
                            {

                                msg.From = new MailAddress(Constants.Connections.EmailFrom);
                                msg.To.Add(muser.Email);
                                msg.Subject = "Password Changed";
                                msg.Body = body.ToString(); ;
                                //msg.Priority = MailPriority.High;
                                msg.IsBodyHtml = true;

                                using (SmtpClient client = new SmtpClient())
                                {
                                    client.EnableSsl = true;
                                    client.UseDefaultCredentials = false;
                                    client.Credentials = new NetworkCredential(Constants.Connections.EmailFrom, Constants.Connections.PassFrom);
                                    client.Host = "smtp.gmail.com";
                                    client.Port = 587;
                                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                                    client.Send(msg);
                                }

                            }
                            bIsOK = datapdater.SetEncryptedUser(muser);
                        }
                        catch (Exception e)
                        {
                            LogMaster lm = new LogMaster();
                            lm.SetLog(e.Message);
                        }
                    }
                }
                
            }
            else
            {
                ErrorMessage = "User with this user name and/or email was not found!";
            }

            return bIsOK;
        }
        protected void UpdateDates()
        {
            Dob = Constants.Values.DummyDate;
            ActivationDate = DateTime.Now;
        }       
    }
}
