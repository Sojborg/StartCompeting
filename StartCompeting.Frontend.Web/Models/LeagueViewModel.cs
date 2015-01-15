using System;
using System.Collections.Generic;
using StartCompeting.Frontend.Web.Api.Controllers;

namespace StartCompeting.Frontend.Web.Models
{
    public class LeagueViewModel
    {
        public int LeagueTypeId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}