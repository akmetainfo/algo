<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 202. Happy Number
// https://leetcode.com/problems/happy-number/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public bool IsHappy(int n)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(0, false)]
[TestCase(1, true)]
[TestCase(2, false)]
[TestCase(3, false)]
[TestCase(4, false)]
[TestCase(5, false)]
[TestCase(6, false)]
[TestCase(7, true)]
[TestCase(8, false)]
[TestCase(9, false)]
[TestCase(10, true)]
[TestCase(11, false)]
[TestCase(12, false)]
[TestCase(13, true)]
[TestCase(14, false)]
[TestCase(15, false)]
[TestCase(16, false)]
[TestCase(17, false)]
[TestCase(18, false)]
[TestCase(19, true)]
[TestCase(20, false)]
[TestCase(21, false)]
[TestCase(22, false)]
[TestCase(23, true)]
[TestCase(24, false)]
[TestCase(25, false)]
[TestCase(26, false)]
[TestCase(27, false)]
[TestCase(28, true)]
[TestCase(29, false)]
[TestCase(30, false)]
[TestCase(31, true)]
[TestCase(32, true)]
[TestCase(33, false)]
[TestCase(34, false)]
[TestCase(35, false)]
[TestCase(36, false)]
[TestCase(37, false)]
[TestCase(38, false)]
[TestCase(39, false)]
[TestCase(40, false)]
[TestCase(41, false)]
[TestCase(42, false)]
[TestCase(43, false)]
[TestCase(44, true)]
[TestCase(45, false)]
[TestCase(46, false)]
[TestCase(47, false)]
[TestCase(48, false)]
[TestCase(49, true)]
[TestCase(50, false)]
[TestCase(51, false)]
[TestCase(52, false)]
[TestCase(53, false)]
[TestCase(54, false)]
[TestCase(55, false)]
[TestCase(56, false)]
[TestCase(57, false)]
[TestCase(58, false)]
[TestCase(59, false)]
[TestCase(60, false)]
[TestCase(61, false)]
[TestCase(62, false)]
[TestCase(63, false)]
[TestCase(64, false)]
[TestCase(65, false)]
[TestCase(66, false)]
[TestCase(67, false)]
[TestCase(68, true)]
[TestCase(69, false)]
[TestCase(70, true)]
[TestCase(71, false)]
[TestCase(72, false)]
[TestCase(73, false)]
[TestCase(74, false)]
[TestCase(75, false)]
[TestCase(76, false)]
[TestCase(77, false)]
[TestCase(78, false)]
[TestCase(79, true)]
[TestCase(80, false)]
[TestCase(81, false)]
[TestCase(82, true)]
[TestCase(83, false)]
[TestCase(84, false)]
[TestCase(85, false)]
[TestCase(86, true)]
[TestCase(87, false)]
[TestCase(88, false)]
[TestCase(89, false)]
[TestCase(90, false)]
[TestCase(91, true)]
[TestCase(92, false)]
[TestCase(93, false)]
[TestCase(94, true)]
[TestCase(95, false)]
[TestCase(96, false)]
[TestCase(97, true)]
[TestCase(98, false)]
[TestCase(99, false)]
[TestCase(100, true)]
[TestCase(101, false)]
[TestCase(102, false)]
[TestCase(103, true)]
[TestCase(104, false)]
[TestCase(105, false)]
[TestCase(106, false)]
[TestCase(107, false)]
[TestCase(108, false)]
[TestCase(109, true)]
[TestCase(110, false)]
[TestCase(111, false)]
[TestCase(112, false)]
[TestCase(113, false)]
[TestCase(114, false)]
[TestCase(115, false)]
[TestCase(116, false)]
[TestCase(117, false)]
[TestCase(118, false)]
[TestCase(119, false)]
[TestCase(120, false)]
[TestCase(121, false)]
[TestCase(122, false)]
[TestCase(123, false)]
[TestCase(124, false)]
[TestCase(125, false)]
[TestCase(126, false)]
[TestCase(127, false)]
[TestCase(128, false)]
[TestCase(129, true)]
[TestCase(130, true)]
[TestCase(131, false)]
[TestCase(132, false)]
[TestCase(133, true)]
[TestCase(134, false)]
[TestCase(135, false)]
[TestCase(136, false)]
[TestCase(137, false)]
[TestCase(138, false)]
[TestCase(139, true)]
[TestCase(140, false)]
[TestCase(141, false)]
[TestCase(142, false)]
[TestCase(143, false)]
[TestCase(144, false)]
[TestCase(145, false)]
[TestCase(146, false)]
[TestCase(147, false)]
[TestCase(148, false)]
[TestCase(149, false)]
[TestCase(150, false)]
[TestCase(151, false)]
[TestCase(152, false)]
[TestCase(153, false)]
[TestCase(154, false)]
[TestCase(155, false)]
[TestCase(156, false)]
[TestCase(157, false)]
[TestCase(158, false)]
[TestCase(159, false)]
[TestCase(160, false)]
[TestCase(161, false)]
[TestCase(162, false)]
[TestCase(163, false)]
[TestCase(164, false)]
[TestCase(165, false)]
[TestCase(166, false)]
[TestCase(167, true)]
[TestCase(168, false)]
[TestCase(169, false)]
[TestCase(170, false)]
[TestCase(171, false)]
[TestCase(172, false)]
[TestCase(173, false)]
[TestCase(174, false)]
[TestCase(175, false)]
[TestCase(176, true)]
[TestCase(177, false)]
[TestCase(178, false)]
[TestCase(179, false)]
[TestCase(180, false)]
[TestCase(181, false)]
[TestCase(182, false)]
[TestCase(183, false)]
[TestCase(184, false)]
[TestCase(185, false)]
[TestCase(186, false)]
[TestCase(187, false)]
[TestCase(188, true)]
[TestCase(189, false)]
[TestCase(190, true)]
[TestCase(191, false)]
[TestCase(192, true)]
[TestCase(193, true)]
[TestCase(194, false)]
[TestCase(195, false)]
[TestCase(196, false)]
[TestCase(197, false)]
[TestCase(198, false)]
[TestCase(199, false)]
[TestCase(200, false)]
[TestCase(201, false)]
[TestCase(202, false)]
[TestCase(203, true)]
[TestCase(204, false)]
[TestCase(205, false)]
[TestCase(206, false)]
[TestCase(207, false)]
[TestCase(208, true)]
[TestCase(209, false)]
[TestCase(210, false)]
[TestCase(211, false)]
[TestCase(212, false)]
[TestCase(213, false)]
[TestCase(214, false)]
[TestCase(215, false)]
[TestCase(216, false)]
[TestCase(217, false)]
[TestCase(218, false)]
[TestCase(219, true)]
[TestCase(220, false)]
[TestCase(221, false)]
[TestCase(222, false)]
[TestCase(223, false)]
[TestCase(224, false)]
[TestCase(225, false)]
[TestCase(226, true)]
[TestCase(227, false)]
[TestCase(228, false)]
[TestCase(229, false)]
[TestCase(230, true)]
[TestCase(231, false)]
[TestCase(232, false)]
[TestCase(233, false)]
[TestCase(234, false)]
[TestCase(235, false)]
[TestCase(236, true)]
[TestCase(237, false)]
[TestCase(238, false)]
[TestCase(239, true)]
[TestCase(240, false)]
[TestCase(241, false)]
[TestCase(242, false)]
[TestCase(243, false)]
[TestCase(244, false)]
[TestCase(245, false)]
[TestCase(246, false)]
[TestCase(247, false)]
[TestCase(248, false)]
[TestCase(249, false)]
[TestCase(250, false)]
[TestCase(251, false)]
[TestCase(252, false)]
[TestCase(253, false)]
[TestCase(254, false)]
[TestCase(255, false)]
[TestCase(256, false)]
[TestCase(257, false)]
[TestCase(258, false)]
[TestCase(259, false)]
[TestCase(260, false)]
[TestCase(261, false)]
[TestCase(262, true)]
[TestCase(263, true)]
[TestCase(264, false)]
[TestCase(265, false)]
[TestCase(266, false)]
[TestCase(267, false)]
[TestCase(268, false)]
[TestCase(269, false)]
[TestCase(270, false)]
[TestCase(271, false)]
[TestCase(272, false)]
[TestCase(273, false)]
[TestCase(274, false)]
[TestCase(275, false)]
[TestCase(276, false)]
[TestCase(277, false)]
[TestCase(278, false)]
[TestCase(279, false)]
[TestCase(280, true)]
[TestCase(281, false)]
[TestCase(282, false)]
[TestCase(283, false)]
[TestCase(284, false)]
[TestCase(285, false)]
[TestCase(286, false)]
[TestCase(287, false)]
[TestCase(288, false)]
[TestCase(289, false)]
[TestCase(290, false)]
[TestCase(291, true)]
[TestCase(292, false)]
[TestCase(293, true)]
[TestCase(294, false)]
[TestCase(295, false)]
[TestCase(296, false)]
[TestCase(297, false)]
[TestCase(298, false)]
[TestCase(299, false)]
[TestCase(300, false)]
[TestCase(301, true)]
[TestCase(302, true)]
[TestCase(303, false)]
[TestCase(304, false)]
[TestCase(305, false)]
[TestCase(306, false)]
[TestCase(307, false)]
[TestCase(308, false)]
[TestCase(309, false)]
[TestCase(310, true)]
[TestCase(311, false)]
[TestCase(312, false)]
[TestCase(313, true)]
[TestCase(314, false)]
[TestCase(315, false)]
[TestCase(316, false)]
[TestCase(317, false)]
[TestCase(318, false)]
[TestCase(319, true)]
[TestCase(320, true)]
[TestCase(321, false)]
[TestCase(322, false)]
[TestCase(323, false)]
[TestCase(324, false)]
[TestCase(325, false)]
[TestCase(326, true)]
[TestCase(327, false)]
[TestCase(328, false)]
[TestCase(329, true)]
[TestCase(330, false)]
[TestCase(331, true)]
[TestCase(332, false)]
[TestCase(333, false)]
[TestCase(334, false)]
[TestCase(335, false)]
[TestCase(336, false)]
[TestCase(337, false)]
[TestCase(338, true)]
[TestCase(339, false)]
[TestCase(340, false)]
[TestCase(341, false)]
[TestCase(342, false)]
[TestCase(343, false)]
[TestCase(344, false)]
[TestCase(345, false)]
[TestCase(346, false)]
[TestCase(347, false)]
[TestCase(348, false)]
[TestCase(349, false)]
[TestCase(350, false)]
[TestCase(351, false)]
[TestCase(352, false)]
[TestCase(353, false)]
[TestCase(354, false)]
[TestCase(355, false)]
[TestCase(356, true)]
[TestCase(357, false)]
[TestCase(358, false)]
[TestCase(359, false)]
[TestCase(360, false)]
[TestCase(361, false)]
[TestCase(362, true)]
[TestCase(363, false)]
[TestCase(364, false)]
[TestCase(365, true)]
[TestCase(366, false)]
[TestCase(367, true)]
[TestCase(368, true)]
[TestCase(369, false)]
[TestCase(370, false)]
[TestCase(371, false)]
[TestCase(372, false)]
[TestCase(373, false)]
[TestCase(374, false)]
[TestCase(375, false)]
[TestCase(376, true)]
[TestCase(377, false)]
[TestCase(378, false)]
[TestCase(379, true)]
[TestCase(380, false)]
[TestCase(381, false)]
[TestCase(382, false)]
[TestCase(383, true)]
[TestCase(384, false)]
[TestCase(385, false)]
[TestCase(386, true)]
[TestCase(387, false)]
[TestCase(388, false)]
[TestCase(389, false)]
[TestCase(390, false)]
[TestCase(391, true)]
[TestCase(392, true)]
[TestCase(393, false)]
[TestCase(394, false)]
[TestCase(395, false)]
[TestCase(396, false)]
[TestCase(397, true)]
[TestCase(398, false)]
[TestCase(399, false)]
[TestCase(400, false)]
[TestCase(401, false)]
[TestCase(402, false)]
[TestCase(403, false)]
[TestCase(404, true)]
[TestCase(405, false)]
[TestCase(406, false)]
[TestCase(407, false)]
[TestCase(408, false)]
[TestCase(409, true)]
[TestCase(410, false)]
[TestCase(411, false)]
[TestCase(412, false)]
[TestCase(413, false)]
[TestCase(414, false)]
[TestCase(415, false)]
[TestCase(416, false)]
[TestCase(417, false)]
[TestCase(418, false)]
[TestCase(419, false)]
[TestCase(420, false)]
[TestCase(421, false)]
[TestCase(422, false)]
[TestCase(423, false)]
[TestCase(424, false)]
[TestCase(425, false)]
[TestCase(426, false)]
[TestCase(427, false)]
[TestCase(428, false)]
[TestCase(429, false)]
[TestCase(430, false)]
[TestCase(431, false)]
[TestCase(432, false)]
[TestCase(433, false)]
[TestCase(434, false)]
[TestCase(435, false)]
[TestCase(436, false)]
[TestCase(437, false)]
[TestCase(438, false)]
[TestCase(439, false)]
[TestCase(440, true)]
[TestCase(441, false)]
[TestCase(442, false)]
[TestCase(443, false)]
[TestCase(444, false)]
[TestCase(445, false)]
[TestCase(446, true)]
[TestCase(447, false)]
[TestCase(448, false)]
[TestCase(449, false)]
[TestCase(450, false)]
[TestCase(451, false)]
[TestCase(452, false)]
[TestCase(453, false)]
[TestCase(454, false)]
[TestCase(455, false)]
[TestCase(456, false)]
[TestCase(457, false)]
[TestCase(458, false)]
[TestCase(459, false)]
[TestCase(460, false)]
[TestCase(461, false)]
[TestCase(462, false)]
[TestCase(463, false)]
[TestCase(464, true)]
[TestCase(465, false)]
[TestCase(466, false)]
[TestCase(467, false)]
[TestCase(468, false)]
[TestCase(469, true)]
[TestCase(470, false)]
[TestCase(471, false)]
[TestCase(472, false)]
[TestCase(473, false)]
[TestCase(474, false)]
[TestCase(475, false)]
[TestCase(476, false)]
[TestCase(477, false)]
[TestCase(478, true)]
[TestCase(479, false)]
[TestCase(480, false)]
[TestCase(481, false)]
[TestCase(482, false)]
[TestCase(483, false)]
[TestCase(484, false)]
[TestCase(485, false)]
[TestCase(486, false)]
[TestCase(487, true)]
[TestCase(488, false)]
[TestCase(489, false)]
[TestCase(490, true)]
[TestCase(491, false)]
[TestCase(492, false)]
[TestCase(493, false)]
[TestCase(494, false)]
[TestCase(495, false)]
[TestCase(496, true)]
[TestCase(497, false)]
[TestCase(498, false)]
[TestCase(499, false)]
[TestCase(500, false)]
public void SolutionTests(int n, bool expected)
{
var actual = new Solution().IsHappy(n);
Assert.That(actual, Is.EqualTo(expected));
}

#region unit tests runner

void Main()
{
var workDir = Path.Combine(Util.MyQueriesFolder, "nunit-work");

var args = new string[]
{
         "-noheader",
         $"--work={workDir}",
    };

RunUnitTests(args);
}

void RunUnitTests(string[] args, Assembly assembly = null)
{
    Console.SetOut(new NoDisposeTextWriter(Console.Out));
    Console.SetError(new NoDisposeTextWriter(Console.Error));
    new AutoRun(assembly ?? Assembly.GetExecutingAssembly()).Execute(args);
}

// https://stackoverflow.com/q/52883672/5752652
class NoDisposeTextWriter : TextWriter
{
    private readonly TextWriter writer;
    public NoDisposeTextWriter(TextWriter writer) => this.writer = writer;

    public override Encoding Encoding => writer.Encoding;
    public override IFormatProvider FormatProvider => writer.FormatProvider;
    public override void Write(char value) => writer.Write(value);
    public override void Flush() => writer.Flush();
    // forward all other overrides as necessary

    protected override void Dispose(bool disposing)
    {
        // no nothing
    }
}

#endregion