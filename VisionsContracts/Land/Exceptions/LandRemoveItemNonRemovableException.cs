using System;

namespace VisionsContracts.Land.Exceptions {
    public class LandRemoveUsingCookingDeviceException : Exception {
        public LandRemoveUsingCookingDeviceException() : base("It is not possible to remove this item while in use") { }
    }

    public class LandRemoveItemNonRemovableException : Exception {
        public LandRemoveItemNonRemovableException() : base("It is not possible to remove this item") { }
    }

    public class LandRemoveTableOrChairWhileCookingException : Exception {
        public LandRemoveTableOrChairWhileCookingException() : base("Tables and chairs cannot be removed or moved while cooking") { }
    }
}
