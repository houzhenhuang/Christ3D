using Christ3D.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.Validations.Student
{
    public class RemoveStudentCommandValidation : StudentValidation<RemoveStudentCommand>
    {
        public RemoveStudentCommandValidation()
        {
            ValidateId();
        }
    }
}
