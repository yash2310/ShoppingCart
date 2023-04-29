﻿using ShoppingCart.Application.DTOs.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.DataService.PublisherDataService.Interface
{
    public interface IPaymentMessageBusClient
    {
        void PublishNewPayment(PaymentMessageBusDto paymentMessageBusDto);
    }
}
