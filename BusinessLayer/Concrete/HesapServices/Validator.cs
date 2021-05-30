using DataEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete.HesapServices
{
    public static class Validator
    {
        public static Result ValidateCargo(bool ispet, bool isLiquid, bool isDanger)
        {

            if (isLiquid)
            {
                return new Result { IsSuccess = false, Message = "The package can not contains liqiud!" };
            }
            else if (ispet)
            {
                return new Result { IsSuccess = false, Message = "The package can not contains pet!" };
            }
            else if (isDanger)
            {
                return new Result { IsSuccess = false, Message = "The package can not contains Danger Metarial!" };
            }
            else
            {
                return new Result { IsSuccess = true, Message = "The package passed validation!!" };

            }

        }
    }
}
