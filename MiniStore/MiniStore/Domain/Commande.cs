﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniStore.Domain
{
    public class Commande
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }                // PK
        public string UserId { get; set; }          // Foreign Key
        public bool IsSent { get; set; } = false;   // Pour qu'il apparaisse dans la liste des commandes à envoyer
        public bool IsPaid { get; set; } = false;   // Pour qu'il apparaisse dans la liste des commandes à payer
        // Navigation properties
        public Guid? AddressId { get; set; }        // Foreign Key
        public Address Address { get; set; }        // Propriété de navigation probable
        public int CommandStatusId { get; set; }    // Foreign Key
    }
}
