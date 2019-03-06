using System;

namespace CodeJam.Problems
{
    public class SnowWhiteProblem : IProblem
    {
        public bool CheckOutput(string output)
        {
            if (output == null) return false;

            output = output.Trim(new char[] { '\r', '\n', ' ' });
            var outputLines = output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var answerLines = Answer.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            if (answerLines.Length != outputLines.Length) return false;

            for (var i = 0; i < answerLines.Length; i++)
            {
                if (!answerLines[i].Equals(outputLines[i], StringComparison.Ordinal)) return false;
            }

            return true;
        }

        public string TaskId => "snieguole";

        public string Input =>
@"100
245620
100101
4001011121
76
A0B170A
77
31384632930
21762
414B67B3BB1477
11
27CBC
220220301310
130287A212B0
826164257253537
3310
512
46540
50121222
4B54AB468486
93D1
1
1300
434
A
19D
101010
1110102112200
A6524484010A15
31011240
35701532673
567
10111
302112113
1020122121211
2112121
3501104254210
B34A80
31333011002
7335835798
231120032031
263325
13002201310
1003423431
10413312231112
216496B6
3B02
18551027
333312443242
251B4443
25DD
2111202112
64947A35494486
836728088555423
1350350211325
54
91
4A4037
11010011111021
12000100
822DCB312DBAC4E
1414521322
C6D718448B9
384A0B364B581
A3436245A
874
13045653332
4780432
23613421
2210030323
222112202122
74
1010110
278B9A4C0
1222012
10212311203
97848
11100
61732334771
2D1D
8DDCB958
45183
11110011000
AB8617C51BDB2D
133373277
4273B
757556654751
F6F3
5884155A
B
2644162161327
623412
168
513
330132
1210000
10
1184
7A5
1206176A31
26220253114652
";

        const string Answer =
@"Testas #1: TAIP
Testas #2: NE
Testas #3: TAIP
Testas #4: NE
Testas #5: NE
Testas #6: TAIP
Testas #7: TAIP
Testas #8: TAIP
Testas #9: TAIP
Testas #10: TAIP
Testas #11: NE
Testas #12: TAIP
Testas #13: TAIP
Testas #14: TAIP
Testas #15: TAIP
Testas #16: NE
Testas #17: TAIP
Testas #18: NE
Testas #19: NE
Testas #20: NE
Testas #21: NE
Testas #22: TAIP
Testas #23: TAIP
Testas #24: NE
Testas #25: TAIP
Testas #26: TAIP
Testas #27: TAIP
Testas #28: NE
Testas #29: TAIP
Testas #30: TAIP
Testas #31: TAIP
Testas #32: NE
Testas #33: TAIP
Testas #34: TAIP
Testas #35: TAIP
Testas #36: TAIP
Testas #37: TAIP
Testas #38: TAIP
Testas #39: NE
Testas #40: TAIP
Testas #41: TAIP
Testas #42: TAIP
Testas #43: TAIP
Testas #44: TAIP
Testas #45: TAIP
Testas #46: TAIP
Testas #47: TAIP
Testas #48: NE
Testas #49: NE
Testas #50: NE
Testas #51: NE
Testas #52: TAIP
Testas #53: NE
Testas #54: TAIP
Testas #55: TAIP
Testas #56: TAIP
Testas #57: TAIP
Testas #58: NE
Testas #59: TAIP
Testas #60: NE
Testas #61: NE
Testas #62: NE
Testas #63: NE
Testas #64: TAIP
Testas #65: NE
Testas #66: TAIP
Testas #67: TAIP
Testas #68: NE
Testas #69: TAIP
Testas #70: TAIP
Testas #71: NE
Testas #72: TAIP
Testas #73: TAIP
Testas #74: TAIP
Testas #75: NE
Testas #76: TAIP
Testas #77: TAIP
Testas #78: NE
Testas #79: NE
Testas #80: NE
Testas #81: TAIP
Testas #82: TAIP
Testas #83: NE
Testas #84: TAIP
Testas #85: NE
Testas #86: TAIP
Testas #87: NE
Testas #88: TAIP
Testas #89: NE
Testas #90: TAIP
Testas #91: TAIP
Testas #92: TAIP
Testas #93: TAIP
Testas #94: TAIP
Testas #95: TAIP
Testas #96: TAIP
Testas #97: TAIP
Testas #98: NE
Testas #99: NE
Testas #100: NE
";
    }
}
