﻿using System;

namespace CodeJam.Problems
{
    public class Problem2 : IProblem
    {
        public bool IsSoved(string output)
        {
            if (output == null) return false;

            output = output.Trim(new char[] { '\r', '\n', ' ' });

            throw new NotImplementedException();
        }

        public string Id => "Problem2Id";

        public string Input => "";
    }
}
