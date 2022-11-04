using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniStore.Entity;

namespace MiniStore.Models
{
    public record MinisDetails(
        int Id,
        string ImagePath, string Name, string Description, 
        double NormalPrice, int Quantity, 
        List<Review> Reviews, int StatusId);
}
