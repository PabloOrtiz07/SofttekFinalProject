using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class TransfersModel
    {
        public TransfersCryptoOriginDTO? TransfersCryptoOrigin { get; set; }
        public TransfersFiduciaryOriginDTO? TransfersFiduciaryOrigin { get; set; }
        public TransfersFiduciaryDestinationDTO? TransfersFiduciaryDestination { get; set; }
        public TransfersCryptoDestinationDTO? TransfersCryptoDestination { get; set; }

    }
}
