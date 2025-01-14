﻿using System;
using System.Collections.Generic;
using MiniStore.Domain;

namespace MiniStore.Models
{
    public record MinisDetails(
        Guid Id,
        string ImagePath, string Name, string Description, 
        double NormalPrice, int Quantity, 
        List<Review> Reviews, int StatusId);
}
