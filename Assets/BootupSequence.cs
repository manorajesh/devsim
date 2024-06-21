using System.Collections;
using TMPro;
using UnityEngine;

public class BootupSequence : MonoBehaviour
{
    public TextMeshProUGUI consoleText;
    public float scrollSpeed = 0.1f;
    public int maxLines = 20;
    public string bootupText = "[    0.804903@0] plat->state_name:default\n[    0.808627@0] master_no = 3, maseter_regs=fe1087e0\n[    0.813400@0] set i2c pinmux error\n[    0.816829@0] aml-i2c i2c-C: add adapter aml_i2c_adap3(ed813088)\n[    0.822761@0] aml-i2c i2c-C: aml i2c bus driver.\n[    0.827381@0] drivers/amlogic/i2c/aml_i2c.c : aml_i2c_probe\n[    0.832901@0] plat->state_name:default\n[    0.836626@0] master_no = 4, maseter_regs=fe108d20\n[    0.841477@0] aml-i2c i2c-D: add adapter aml_i2c_adap4(ed813888)\n[    0.847370@0] aml-i2c i2c-D: aml i2c bus driver.\n[    0.852058@0] aml_pmu_init, 347\n[    0.855107@0] call aml_dvfs_init in\n[    0.858601@0] [DVFS]aml_dvfs_probe, child name:vcck_dvfs\n[    0.863851@0] [DVFS]dvfs table of vcck_dvfs is:\n[    0.868346@0] [DVFS]     freq,    min_uV,    max_uV\n[    0.873208@0] [DVFS]    96000,    825000,    825000\n[    0.878054@0] [DVFS]   192000,    825000,    825000\n[    0.882914@0] [DVFS]   312000,    825000,    825000\n[    0.887762@0] [DVFS]   408000,    825000,    825000\n[    0.892622@0] [DVFS]   504000,    825000,    825000\n[    0.897470@0] [DVFS]   600000,    850000,    850000\n[    0.902330@0] [DVFS]   720000,    850000,    850000\n[    0.907179@0] [DVFS]   816000,    875000,    875000\n[    0.912039@0] [DVFS]  1008000,    925000,    925000\n[    0.916887@0] [DVFS]  1200000,    975000,    975000\n[    0.921747@0] [DVFS]  1416000,   1025000,   1025000\n[    0.926596@0] [DVFS]  1608000,   1100000,   1100000\n[    0.931456@0] [DVFS]  1800000,   1125000,   1125000\n[    0.936304@0] [DVFS]  1992000,   1125000,   1125000\n[    0.941230@0] hdmitx: system: amhdmitx_init\n[    0.945319@0] hdmitx: system: Ver: 2014Jan5a\n[    0.949637@0] hdmitx: system: amhdmitx_probe\n[    0.954135@0] hdmitx: system: ALREADY init VIC = 21\n[    0.959121@1] hdmitx: system: reset intr mask\n[    0.993885@0] bio: create slab <bio-0> at 0\n";

    public delegate void BootupCompleteHandler();
    public event BootupCompleteHandler OnBootupComplete;

    void Start()
    {
        StartCoroutine(ShowBootupSequence());
    }

    IEnumerator ShowBootupSequence()
    {
        consoleText.text = "";
        string[] bootupLines = bootupText.Split('\n');

        foreach (string line in bootupLines)
        {
            AddLine(line);
            yield return new WaitForSeconds(scrollSpeed);
        }

        OnBootupComplete?.Invoke();
    }

    void AddLine(string newLine)
    {
        string[] lines = consoleText.text.Split('\n');

        if (lines.Length >= maxLines)
        {
            // Remove the oldest line
            consoleText.text = string.Join("\n", lines, 1, lines.Length - 1);
        }

        consoleText.text += newLine + "\n";
    }
}
