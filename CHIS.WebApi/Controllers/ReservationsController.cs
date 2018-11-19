﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CHIS.Core.Domain;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace CHIS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public ReservationsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Reservations
        [HttpGet]
        public IEnumerable<reservations> Getreservations()
        {
            return _context.reservations.Include(a => a.account_)
                .Include(a => a.reserved_rooms).OrderByDescending(a=>a.id);
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getreservations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservations = await _context.reservations.FindAsync(id);

            if (reservations == null)
            {
                return NotFound();
            }

            return Ok(reservations);
        }

        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putreservations([FromRoute] int id, [FromBody] reservations reservations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservations.id)
            {
                return BadRequest();
            }

            _context.Entry(reservations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reservationsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reservations
        [HttpPost]
        public async Task<IActionResult> Postreservations([FromBody] reservations reservations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.reservations.Add(reservations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getreservations", new { id = reservations.id }, reservations);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletereservations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservations = await _context.reservations.FindAsync(id);
            if (reservations == null)
            {
                return NotFound();
            }

            _context.reservations.Remove(reservations);
            await _context.SaveChangesAsync();

            return Ok(reservations);
        }

        private bool reservationsExists(int id)
        {
            return _context.reservations.Any(e => e.id == id);
        }

        [HttpPost("searchReservationWithParam")]
        public IActionResult searchReservationWithParam([FromBody]List<SearchParameter> data)
        {
            var sql = "SELECT * FROM reservations WHERE ";
            var isFirst = true;
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append(sql);

            foreach (var param in data)
            {
                var list = param.Field.Split("|");
                var field = list[0];
                var format = list[1];
            
                if (param.Condition == "CN")
                {
                    if (isFirst)
                    {

                        sql = String.Format(" {0} like '%{1}%'", field, param.Value);
                    }
                    else
                    {
                        sql = String.Format("  AND {0} like '%{1}%'", field, param.Value);
                    }
                  
                }
                else
                {
                    if (isFirst)
                    {
                        switch (format)
                        {
                            case "number":
                                sql = String.Format(" {0}{1}{2} ", field, param.Condition, param.Value);
                                break;
                            case "text":
                                sql = String.Format(" {0}{1}'{2}' ", field, param.Condition, param.Value);
                                break;
                            case "date":
                                sql = String.Format(" DATE({0}){1}'{2}' ", field, param.Condition, param.Value);
                                break;
                            default:
                                break;
                        }
                     
                    }
                    else
                    {
                        switch (format)
                        {
                            case "number":
                                sql = String.Format(" AND {0}{1}{2} ", field, param.Condition, param.Value);
                                break;
                            case "text":
                                sql = String.Format(" AND {0}{1}'{2}' ", field, param.Condition, param.Value);
                                break;
                            case "date":
                                sql = String.Format(" AND DATE({0}){1}'{2}' ", field, param.Condition, param.Value);
                                break;
                            default:
                                break;
                        }

                    }


                }
                sqlBuilder.Append(sql);
                isFirst = false;

            }

            var reservations = _context.reservations.FromSql(sqlBuilder.ToString(), "").Include(a=>a.reserved_rooms).
                Include(a=>a.reservation_transaction).ToList();

            return Ok(reservations);
        }

        [HttpPost("get_total_reservation_rate")]
        public IActionResult get_total_reservation_rate([FromBody]Posted_Data data)
        {
            var bookingForm = data.bookingForm;
            var userForm = data.userForm;
            var businessForm = data.businessForm;
            var rooms = data.rms;

            

            var rs = new reservations();
            var arrival_string = bookingForm.arrival.Split("/");
            var new_arrival_date = String.Format("{0}-{1}-{2}", arrival_string[2], arrival_string[0], arrival_string[1]);
            rs.arrival = DateTime.Parse(new_arrival_date);
            rs.arrival_time = bookingForm.arrival_time;
         

            rs.departure = rs.arrival.Value.AddDays(int.Parse(bookingForm.num_of_night));
            rs.num_of_night = int.Parse(bookingForm.num_of_night);
       



            foreach (var room in rooms)
            {
                var dd = new reserved_rooms();
                dd.arrival = rs.arrival;
                dd.arrival_time = rs.arrival_time;
                dd.balance = 0M;
                dd.created = rs.created;
                dd.departure = DateTime.Now;
                dd.departure_time = "";
                dd.modified = DateTime.Now;
                dd.num_of_night = rs.num_of_night;
                dd.paid = 0M;
                dd.modified = DateTime.Now;
                dd.reserved_status = "Open";
                dd.room_id = int.Parse(room.id);
                dd.room_type_id = int.Parse(room.room_type_id);
               
                dd.num_of_night = rs.num_of_night;
                dd.num_of_adult = int.Parse(room.extra_adult);
                dd.num_of_children = int.Parse(room.extra_children);
                dd.room_name = room.room_name;
                dd.room_type_name = room.room_type_name;

               

                rs.reserved_rooms.Add(dd);

            }

            foreach (var rr in rs.reserved_rooms)
            {
                for (int i = 0; i < rs.num_of_night; i++)
                {
                    var tran = new reservation_transaction();
                    var rate = getRoomRate(rs.arrival.Value.AddDays(i), rr.room_type_id);
                    tran.total_reservation = rate.amount.Value;
                    tran.total_children = rr.num_of_children * rate.extra_child;
                    tran.total_adult = rr.num_of_adult * rate.extra_adult;
                    tran.total = tran.total_adult + tran.total_children + tran.total_reservation;
                    tran.balance = tran.total;
                    tran.created = DateTime.Now;
                    tran.modified = DateTime.Now;
                    tran.paid = 0M;
                    tran.rate = rate.amount;
                    tran.reservation_id = rs.id;
                    tran.reserved_room_id = rr.id;
                    tran.status = "Open";
                    tran.transaction_date = rs.arrival.Value.AddDays(i);
                    tran.rate_type = _context.rate_types.Where(a => a.id == rate.rate_type_id).FirstOrDefault().rate_type_name;
                    tran.rate_name = rate.rate_name;
                    tran.reserved_room_ = rr;
                
                    rs.reservation_transaction.Add(tran);

                }
            }

          




            return Ok(rs);
        }


        [HttpPost("post_reservations")]
        public   IActionResult post_reservations([FromBody]Posted_Data data)
        {
            var bookingForm = data.bookingForm;
            var userForm = data.userForm;
            var businessForm = data.businessForm;
            var rooms = data.rms;
            var paymentForm = data.paymentForm;


            var userId = int.Parse(userForm.id);

            accounts ac = null;

            if(userId > 0)
            {
                ac = _context.accounts.Where(a=>a.id==userId).FirstOrDefault();               
                ac.address1 = userForm.address1;
                ac.address2 = userForm.address2;              
                ac.city = userForm.city;
                ac.country = userForm.country;              
                ac.email = userForm.email;
                ac.fax = userForm.fax;
                ac.first_name = userForm.first_name;
                ac.last_name = userForm.last_name;              
                ac.phone = userForm.phone;
                ac.postal_code = userForm.postal_code;
                ac.state = userForm.state;
                _context.SaveChanges();
            }
            else
            {
                ac = new accounts();
                ac.account_number = CHIS.Core.Infrastructure.AccountGenerator.Generate(10);
                var account_type = _context.account_types.Select(a => a).OrderBy(a => a.id).FirstOrDefault();
                if (account_type != null)
                {
                    ac.account_type_id = account_type.id;
                }
                ac.address1 = userForm.address1;
                ac.address2 = userForm.address2;
                ac.alias = "AC";
                ac.card_holder = "";
                ac.city = userForm.city;
                ac.country = userForm.country;
                ac.created = DateTime.Now;
                ac.created_by = "1";
                ac.created_on = DateTime.Now;
                ac.credit_card_type = "";
                ac.credit_limit = 500M;
                ac.email = userForm.email;
                ac.exp_date = DateTime.Now;
                ac.fax = userForm.fax;
                ac.first_name = userForm.first_name;
                ac.last_name = userForm.last_name;
                ac.modified = DateTime.Now;
                ac.opening_balance = 0M;
                ac.payment_term = 0M;
                ac.phone = userForm.phone;
                ac.postal_code = userForm.postal_code;
                ac.reg_number = "";
                ac.reg_number1 = "";
                ac.reg_number2 = "";
                ac.remark = "";
                ac.state = userForm.state;
                _context.accounts.Add(ac);
                _context.SaveChanges();
            }

            
            

           
           

            var rs = new reservations();
            rs.account_id = ac.id;
            var arrival_string = bookingForm.arrival.Split("/");
            var new_arrival_date = String.Format("{0}-{1}-{2}", arrival_string[2], arrival_string[0], arrival_string[1]);
            rs.arrival = DateTime.Parse(new_arrival_date);  
            rs.arrival_time =  bookingForm.arrival_time;
            rs.book_by = bookingForm.book_by;
            rs.book_on = DateTime.Now;
            rs.business_source_id = int.Parse(businessForm.business_source_id);
            rs.code = Guid.NewGuid().ToString();
            rs.created = DateTime.Now;
            rs.departure = rs.arrival.Value.AddDays(int.Parse(bookingForm.num_of_night));
            rs.departure_time = bookingForm.departure_time;
            rs.modified = DateTime.Now;
            rs.num_of_night = int.Parse(bookingForm.num_of_night);
            rs.reservation_number = CHIS.Core.Infrastructure.AccountGenerator.Generate(8);
            rs.reservation_status = "Open";
            rs.account_number = paymentForm.account_number;
            rs.apply_discount = paymentForm.apply_discount;
            rs.bank_name = paymentForm.bank_name;
            rs.branch_name = paymentForm.branch_name;
            rs.cheque = paymentForm.cheque;
            rs.discount_code = paymentForm.discount_code;
            rs.discount_plan = int.Parse(paymentForm.discount_plan);
            rs.discount_value = Decimal.Parse(paymentForm.discount_value);
            rs.amount_paid = Decimal.Parse(paymentForm.amount);
            rs.balance = Decimal.Parse(paymentForm.balance);
            rs.total_booking = Decimal.Parse(paymentForm.total_amount);
        


            _context.reservations.Add(rs);
            _context.SaveChanges();



            foreach (var room in rooms)
            {
                var dd = new reserved_rooms();
                dd.arrival = rs.arrival;
                dd.arrival_time = rs.arrival_time;
                dd.balance = Decimal.Parse(paymentForm.balance);
                dd.created = rs.created;
                dd.departure = DateTime.Now;
                dd.departure_time = "";
                dd.modified = DateTime.Now;
                dd.num_of_night = rs.num_of_night;
                dd.original_owner = ac.first_name + " " + ac.last_name;
                dd.paid = Decimal.Parse(paymentForm.amount);
                dd.reservation_id = rs.id;
                dd.modified = DateTime.Now;
                dd.reserved_status = "Open";
                dd.room_id =int.Parse(room.id);
                dd.room_type_id = int.Parse(room.room_type_id);
                dd.serial_number = CHIS.Core.Infrastructure.AccountGenerator.Generate(8);
                dd.status = "Open";
                dd.total = Decimal.Parse(paymentForm.total_amount);
                dd.transfer_owner = "";
                dd.num_of_night = rs.num_of_night;
                dd.num_of_adult = int.Parse(room.extra_adult);
                dd.num_of_children = int.Parse(room.extra_children);
                dd.room_name = room.room_name;
                dd.room_type_name = room.room_type_name;

                _context.reserved_rooms.Add(dd);
                _context.SaveChanges();



                rs.reserved_rooms.Add(dd);

            }

            foreach (var rr in rs.reserved_rooms)
            {
                for(int i=0; i < rs.num_of_night; i++)
                {
                    var tran = new reservation_transaction();
                    var rate = getRoomRate(rs.arrival.Value.AddDays(i), rr.room_type_id);
                    tran.total_reservation = rate.amount.Value;
                    tran.total_children = rr.num_of_children * rate.extra_child;
                    tran.total_adult = rr.num_of_adult * rate.extra_adult;
                    tran.total = tran.total_adult + tran.total_children + tran.total_reservation;
                    tran.balance = tran.total;
                    tran.created = DateTime.Now;
                    tran.modified = DateTime.Now;
                    tran.paid = Decimal.Parse(paymentForm.amount);
                    tran.rate = rate.amount;
                    tran.reservation_id = rs.id;
                    tran.reserved_room_id = rr.id;
                    tran.status = "Open";
                    tran.transaction_date = rs.arrival.Value.AddDays(i);
                    tran.rate_type = _context.rate_types.Where(a => a.id == rate.rate_type_id).FirstOrDefault().rate_type_name;
                    tran.rate_name = rate.rate_name;
                  
                    tran.payment_method = paymentForm.payment_method;
                    tran.room_name = rr.room_name;
                    tran.room_Type = rr.room_type_name;
                    _context.reservation_transaction.Add(tran);
                    _context.SaveChanges();
                    rs.reservation_transaction.Add(tran);
                    
                }
            }

            _context.SaveChanges();




            return Ok(rs);
        }


        [HttpPost("edit_reserved_room")]
        public IActionResult edit_reserved_room([FromBody] EditReservationData data)
        {
            var reservation_id = int.Parse(data.reservation_id);
            var reserved_room_id = int.Parse(data.reserved_room_id);
            var change_value = int.Parse(data.change_value);
            var type = data.type;

            var reservation = _context.reservations.Where(a => a.id == reservation_id).Include(a=>a.reserved_rooms)
                .Include(a=>a.reservation_transaction).FirstOrDefault();
            var reserved_room = _context.reserved_rooms.Where(a => a.id == reserved_room_id).Include(a=>a.reservation_transaction).FirstOrDefault();
            if (type == "adult")
            {
                if (reserved_room.num_of_adult == change_value)
                {
                    return Ok(reservation);
                }
                else
                {                  
             
                    reserved_room.num_of_adult = change_value;
                    _context.SaveChanges();

                    reservation.total_booking = 0M;
                    foreach (var tran in reserved_room.reservation_transaction)
                    {
                        var rate = getRoomRate(tran.transaction_date.Value, reserved_room.room_type_id);
                        tran.total_reservation = rate.amount.Value;
                        tran.total_children = reserved_room.num_of_children * rate.extra_child;
                        tran.total_adult = reserved_room.num_of_adult * rate.extra_adult;
                        tran.total = tran.total_adult + tran.total_children + tran.total_reservation;
                        tran.balance = tran.total;
                        tran.rate = rate.amount;
                        tran.rate_type = _context.rate_types.Where(a => a.id == rate.rate_type_id).FirstOrDefault().rate_type_name;
                        tran.rate_name = rate.rate_name;
                        reservation.total_booking += tran.total;
                        _context.SaveChanges();
                    }

                    reservation.balance = reservation.total_booking - reservation.amount_paid;
                    reserved_room.balance = reservation.balance;
                    reserved_room.total = reservation.total_booking;
                    _context.SaveChanges();
                    reservation = _context.reservations.Where(a => a.id == reservation_id).Include(a => a.reserved_rooms)
                                  .Include(a => a.reservation_transaction).FirstOrDefault();
                    return Ok(reservation);

                }
            }
            else
            {
                if (reserved_room.num_of_children == change_value)
                {
                    return Ok(reservation);
                }
                else
                {
                    reserved_room.num_of_children = change_value;
                    _context.SaveChanges();


                    foreach (var tran in reserved_room.reservation_transaction)
                    {
                        var rate = getRoomRate(tran.transaction_date.Value, reserved_room.room_type_id);
                        tran.total_reservation = rate.amount.Value;
                        tran.total_children = reserved_room.num_of_children * rate.extra_child;
                        tran.total_adult = reserved_room.num_of_adult * rate.extra_adult;
                        tran.total = tran.total_adult + tran.total_children + tran.total_reservation;
                        tran.balance = tran.total;
                        tran.rate = rate.amount;
                        tran.rate_type = _context.rate_types.Where(a => a.id == rate.rate_type_id).FirstOrDefault().rate_type_name;
                        tran.rate_name = rate.rate_name;
                        _context.SaveChanges();
                    }
                    reservation.balance = reservation.total_booking - reservation.amount_paid;
                    reserved_room.balance = reservation.balance;
                    reserved_room.total = reservation.total_booking;
                    _context.SaveChanges();
                    reservation = _context.reservations.Where(a => a.id == reservation_id).Include(a => a.reserved_rooms)
                                  .Include(a => a.reservation_transaction).FirstOrDefault();
                    return Ok(reservation);

                }
            }
        }
        public rates getRoomRate(DateTime day, int roomTypeId)
        {
            var roomRates =  _context.room_types_rates.Include(a => a.rate_).Where(a => a.room_type_id == roomTypeId).ToList();
            var day_name = day.DayOfWeek.ToString();
            var isWeekDay =  _context.week_days.Where(a => a.day_name.ToLower().Equals(day_name.ToLower())).Select(a => a.isweekday).FirstOrDefault();
            var rate = roomRates.Where(a => a.rate_.isweekday == isWeekDay).FirstOrDefault();
            return rate.rate_;
        }

       
    }


    public class EditReservationData
    {
        public String reservation_id { set; get; }
        public String reserved_room_id { set; get; }
        public String change_value { set; get; }
        public String type { set; get; }
    }
  
    public class Posted_Data
    {
        public BookingForm bookingForm { get; set; }
        public UserForm userForm { set; get; }
        public BusinessForm businessForm { get; set; }
        public List<_room>  rms { get; set; }
        public PaymentForm paymentForm { get; set; }
    }

    

    public class BookingForm
    {
        public String arrival { set; get; }
       public String arrival_time { set; get; }
       public String departure { get; set; }
       public String departure_time { set; get; }
       public String num_of_night { set; get; }
       public String account_id { get; set; }
       public String book_by { get; set; }
       public String book_on { get; set; }
       public String payment_method { get; set; }

    }

    public class UserForm
    {
        public String last_name { get; set; }
        public String first_name { get; set; }
        public String address1 { get; set; }
        public String address2 { get; set; }
        public String city { get; set; }
        public String postal_code { get; set; }
        public String state { get; set; }
        public String country { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public String fax { get; set; }
        public String id { get; set; }
    }

    public class BusinessForm
    {
        public String business_source_id { set; get; }
        public String room_type_id { get; set; }
    }

    public class _room
    {
        public String id { get; set; }
        public String room_type_id { get; set; }
        public String floor_id { get; set; }
        public String alias { get; set; }
        public String sort_key { get; set; }
        public String room_name { get; set; }
        public String room_owner_id { get; set; }
        public String phone_extension { get; set; }
        public String data_extension { get; set; }
        public String keycard_alias { get; set; }
        public String power_code { get; set; }
        public String remark { get; set; }
        public String inactive { get; set; }
        public String room_type_name { get; set; }
        public String extra_adult { get; set; }
        public String extra_children { get; set; }
        public String discount_plan { get; set; }
        public String discount_value { get; set; }
        public String discount_code { get; set; }
        public String num_of_adult { get; set; }
        public String num_of_children { get; set; }
    }

    public class PaymentForm
    {
      public String payment_method { get; set; }
        public String total_amount  { get; set; }
        public String amount { get; set; }
        public String balance { get; set; }
        public String cheque { get; set; }
        public String account_number { get; set; }
        public String bank_name { get; set; }
        public String branch_name { get; set; }
        public String discount_plan { get; set; }
        public String discount_value { get; set; }
        public String discount_code { get; set; }
        public String apply_discount { get; set; }
    }

    public class SearchParameter
    {
        public String Field { get; set; }
        public String Condition { get; set; }
        public String  Value  { get; set; }
    }


}