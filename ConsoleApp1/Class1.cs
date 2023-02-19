using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Class1
    {
        private static void Main(string[] args)
        {
            #region Data
            //var flatList = new List<Group>(){
            //  new Group(){ID="C1",ParentID="MM",DSCRA="A",DSCRE="B",FRMNM="C",ORGORD="D",MNUNM="MM.C1"    },
            //  new Group(){ID="C2",ParentID="MM",DSCRA="any data1",DSCRE="any data1",FRMNM="any data2",ORGORD="MM.C1",MNUNM="MM.C2"},
            //  new Group(){ID="C3",ParentID="MM",DSCRA="any data1",DSCRE="any data1",FRMNM="any data3",ORGORD="MM.C3",MNUNM= "MM.C3"    },
            //  new Group(){ID="C32",ParentID="C3", DSCRA="any data1",DSCRE="any data1",FRMNM="any data4",ORGORD="C3.C32",MNUNM= "C3.C32"},
            //  new Group(){ID="C321",ParentID="C32" ,DSCRA="any data1",DSCRE="any data1",FRMNM="any data5",ORGORD="C32.C321",MNUNM = "C32.C321"},
            //  new Group(){ID="C21",ParentID="C2",DSCRA="any data1",DSCRE="any data1",FRMNM="any data3",ORGORD="MM.C3",MNUNM= "C2.C21"    },
            //};
            #endregion
            var list = GetData().OrderByDescending(c => c.MNUNM);
            foreach (var item in list)
            {
                var splittedArr = item.MNUNM.Trim().Split('.');
                item.ParentID = splittedArr[0];
                item.ID = splittedArr[1];
                item.MNUNM = item.MNUNM.Trim();
            }
            var tree = list.OrderByDescending(c => c.MNUNM).BuildTree();//list.BuildTree();
            var json = JsonSerializer.Serialize(tree,
                                            new JsonSerializerOptions
                                            {
                                                WriteIndented = true,
                                                PropertyNamingPolicy = new UpperCaseNamingPolicy()
                                            });
            Console.WriteLine(json);
        }
        private static IList<Group> GetData()
        {
            return new List<Group> { new Group(){MNUNM="C9.GLMNUMNT      "},
new Group(){MNUNM="C9.GLPRMMNT      "},
new Group(){MNUNM="C3.GLSCCMNT      "},
new Group(){MNUNM="C1.GLBRNSEL      "},
new Group(){MNUNM="C3.GLACCMNT      "},
new Group(){MNUNM="C3.GLACCCPY      "},
new Group(){MNUNM="C4.GLTRNMNT      "},
new Group(){MNUNM="C81.GLACCLST     "},
new Group(){MNUNM="C3.GLDOCMNT      "},
new Group(){MNUNM="C3.GLSUPMNT      "},
new Group(){MNUNM="C3.GLCLIMNT      "},
new Group(){MNUNM="C3.GLJRNMNT      "},
new Group(){MNUNM="C81.GLSUPLST     "},
new Group(){MNUNM="C81.GLSALLST     "},
new Group(){MNUNM="C81.GLCLILST     "},
new Group(){MNUNM="C81.GLJRNLST     "},
new Group(){MNUNM="C81.GLDOCLST     "},
new Group(){MNUNM="C81.GLMCCLST     "},
new Group(){MNUNM="C81.GLSCCLST     "},
new Group(){MNUNM="C6.GLTRNPST      "},
new Group(){MNUNM="C1.GLYERCHG      "},
new Group(){MNUNM="C82.GLPSTVIW     "},
new Group(){MNUNM="C3.GLMCCMNT      "},
new Group(){MNUNM="C61.GLTRNUPS     "},
new Group(){MNUNM="C61.GLTRNUPP     "},
new Group(){MNUNM="C4.GLGLTLST      "},
new Group(){MNUNM="C82.GLPSTLST     "},
new Group(){MNUNM="C4.GLOPNMNT      "},
new Group(){MNUNM="C6.GLOPNPST      "},
new Group(){MNUNM="C6.GLOPNUPS      "},
new Group(){MNUNM="C83.GLOPNVIW     "},
new Group(){MNUNM="C82.GLPSTSMR     "},
new Group(){MNUNM="C4.GLGLTSMR      "},
new Group(){MNUNM="C85.GLBALLVL     "},
new Group(){MNUNM="C87.GLPSCSMR     "},
new Group(){MNUNM="C4.GLGLCSMR      "},
new Group(){MNUNM="C6.GLPRDOPN      "},
new Group(){MNUNM="C6.GLPRDCLS      "},
new Group(){MNUNM="C4.GLOPNLST      "},
new Group(){MNUNM="C83.GLOPNLS2     "},
new Group(){MNUNM="C6.GLAUTLVL      "},
new Group(){MNUNM="C7.GLTMPSTMQ     "},
new Group(){MNUNM="C7.GLACCSTMQ     "},
new Group(){MNUNM="C85.GLBALPER     "},
new Group(){MNUNM="C7.GLBALLVLQ     "},
new Group(){MNUNM="C7.GLGLTSMRQ     "},
new Group(){MNUNM="C7.GLPSTSMRQ     "},
new Group(){MNUNM="C7.GLGLCSMRQ     "},
new Group(){MNUNM="C7.GLPSCSMRQ     "},
new Group(){MNUNM="C7.GLTRNQRY      "},
new Group(){MNUNM="C7.GLABLLVLQ     "},
new Group(){MNUNM="C85.GLBLTLVL     "},
new Group(){MNUNM="C87.GLCSTRP2     "},
new Group(){MNUNM="C87.GLCSTRP3     "},
new Group(){MNUNM="C87.GLCSTRP4     "},
new Group(){MNUNM="C87.GLCSTMOV     "},
new Group(){MNUNM="C82.GLTRNSRC     "},
new Group(){MNUNM="C6.GLREBAL       "},
new Group(){MNUNM="C31.GLREPMNT1    "},
new Group(){MNUNM="C31.GLREPMNT2    "},
new Group(){MNUNM="C31.GLREPMNT3    "},
new Group(){MNUNM="C4.GLRECMNT      "},
new Group(){MNUNM="C4.GLPAYMNT      "},
new Group(){MNUNM="C4.GLTRNREV      "},
new Group(){MNUNM="C88.GLCLIRP1     "},
new Group(){MNUNM="C88.GLCLIRP2     "},
new Group(){MNUNM="C89.GLSUPRP1     "},
new Group(){MNUNM="C89.GLSUPRP2     "},
new Group(){MNUNM="C84.GLSTMSUM     "},
new Group(){MNUNM="C4.GLPYTLST      "},
new Group(){MNUNM="C82.GLRCPSMR     "},
new Group(){MNUNM="C82.GLPAYSMR     "},
new Group(){MNUNM="C86.GLACCPER     "},
new Group(){MNUNM="C86.GLACCTOT     "},
new Group(){MNUNM="C3.C31           "},
new Group(){MNUNM="C6.C61           "},
new Group(){MNUNM="C8.C81           "},
new Group(){MNUNM="C81.GLRPTLST     "},
new Group(){MNUNM="C8.C86           "},
new Group(){MNUNM="C86.GLCLSRP      "},
new Group(){MNUNM="C9.GLPSWCHG      "},
new Group(){MNUNM="C8.C85           "},
new Group(){MNUNM="C85.GLBALTRE     "},
new Group(){MNUNM="MM.C1            "},
new Group(){MNUNM="MM.C2            "},
new Group(){MNUNM="MM.C3            "},
new Group(){MNUNM="MM.C4            "},
new Group(){MNUNM="MM.C6            "},
new Group(){MNUNM="MM.C7            "},
new Group(){MNUNM="MM.C8            "},
new Group(){MNUNM="MM.C9            "},
new Group(){MNUNM="MM.CA            "},
new Group(){MNUNM="MM.CB            "},
new Group(){MNUNM="C84.GLSTMACC     "},
new Group(){MNUNM="C84.GLSTMTMP     "},
new Group(){MNUNM="C84.GLSTMMAN     "},
new Group(){MNUNM="C84.GLSTMMA2     "},
new Group(){MNUNM="C8.C84           "},
new Group(){MNUNM="C85.GLBALCMP     "},
new Group(){MNUNM="C8.C88           "},
new Group(){MNUNM="C88.GLCLISTM     "},
new Group(){MNUNM="C8.C89           "},
new Group(){MNUNM="C89.GLSUPSTM     "},
new Group(){MNUNM="C8.C87           "},
new Group(){MNUNM="C8.C83           "},
new Group(){MNUNM="C8.C82           "},
new Group(){MNUNM="C4.GLRCVMNT      "},
new Group(){MNUNM="C4.GLPYVMNT      "},
new Group(){MNUNM="C88.GLCLIPY2     "},
new Group(){MNUNM="C89.GLSUPPY2     "},
new Group(){MNUNM="C30.GLBDGMNT     "},
new Group(){MNUNM="C30.GLBDGMCC     "},
new Group(){MNUNM="C30.GLBDGSCC     "},
new Group(){MNUNM="C3.C30           "},
new Group(){MNUNM="C6.GLCHGACC      "},
new Group(){MNUNM="C88.GLCLIAGE     "},
new Group(){MNUNM="C88.GLCLIAGX     "},
new Group(){MNUNM="C89.GLSUPAGE     "},
new Group(){MNUNM="C89.GLSUPAGX     "},
new Group(){MNUNM="C6.GLYERCLS      "},
new Group(){MNUNM="C7.GLCLSQRY      "},
new Group(){MNUNM="C85.GLBLDL1      "},
new Group(){MNUNM="C85.GLBLDL2      "},
new Group(){MNUNM="C7.GLBLDLVLQ     "},
new Group(){MNUNM="C84.GLSTMCSH     "},
new Group(){MNUNM="C84.GLSTMMCR     "},
new Group(){MNUNM="C86.GLRPTRP      "},
new Group(){MNUNM="C3.C32           "},
new Group(){MNUNM="C32.GLPHYMNT     "},
new Group(){MNUNM="C32.GLPHYMCC     "},
new Group(){MNUNM="C32.GLPHYSCC     "},
new Group(){MNUNM="C7.GLBALQRY      "},
new Group(){MNUNM="C86.GLACCBAL     "},
new Group(){MNUNM="C84.GLSTMCOR     "},
new Group(){MNUNM="C86.GLRPTRP2     "},
new Group(){MNUNM="C88.GLCLIPY1     "},
new Group(){MNUNM="C89.GLSUPPY1     "},
new Group(){MNUNM="C6.GLRPLACC      "},
new Group(){MNUNM="C86.GLRPTMN3     "},
new Group(){MNUNM="C81.GLBDGLST     "},
new Group(){MNUNM="C88.GLCLIPY3     "},
new Group(){MNUNM="C88.GLSALCLC     "},
new Group(){MNUNM="C31.GLREPCPY     "},
new Group(){MNUNM="C87.GLCSTRP5     "},
new Group(){MNUNM="C88.GLSALAGE     "},
new Group(){MNUNM="C88.GLSALRP1     "},
new Group(){MNUNM="C6.GLPYAMNT      "},
new Group(){MNUNM="C6.GLRCAMNT      "},
new Group(){MNUNM="C87.GLMCBDGR     "},
new Group(){MNUNM="C88.GLSALACT     "},
new Group(){MNUNM="C3.GLPRDDEF      "},
new Group(){MNUNM="C4.GLTRNPRD      "},
new Group(){MNUNM="C7.GLCLISTMQ     "},
new Group(){MNUNM="C7.GLSUPSTMQ     "},
new Group(){MNUNM="C88.GLSTMCNF     "},
new Group(){MNUNM="C87.GLSUBRP5     "},
new Group(){MNUNM="C84.GLSTMGRP     "},
new Group(){MNUNM="C3.GLACCGRP      "},
new Group(){MNUNM="C87.GLSUBMOV     "},
new Group(){MNUNM="C87.GLSUBRP2     "},
new Group(){MNUNM="C87.GLSUBRP3     "},
new Group(){MNUNM="C87.GLSUBRP4     "},
new Group(){MNUNM="C6.GLINVPAY      "},
new Group(){MNUNM="C3.C34           "},
new Group(){MNUNM="C34.GLSALMNT     "},
new Group(){MNUNM="C34.GLSALCOM     "},
new Group(){MNUNM="C34.GLSLCMPR     "},
new Group(){MNUNM="C88.GLSLCMYR     "},
new Group(){MNUNM="C88.GLSLCMMN     "},
new Group(){MNUNM="C6.GLPYVACC      "},
new Group(){MNUNM="C7.GLPYVACQ      "},
new Group(){MNUNM="C6.GLPYUACC      "},
new Group(){MNUNM="C88.GLINVACC     "},
new Group(){MNUNM="C88.GLSALSLA     "},
new Group(){MNUNM="C89.GLSUPSTC     "},
new Group(){MNUNM="C4.GLRECMN2      "},
new Group(){MNUNM="C84.GLSTMTCR     "},
new Group(){MNUNM="C84.GLSTMCUR     "},
new Group(){MNUNM="C4.GLPAYMN2      "},
new Group(){MNUNM="C7.GLDLTQRY      "},
new Group(){MNUNM="C7.GLSLCQRY      "},
new Group(){MNUNM="C4.C42           "},
new Group(){MNUNM="C42.GLADJPRP     "},
new Group(){MNUNM="C42.GLBNKADJ     "},
new Group(){MNUNM="C6.GLCURDIF      "},
new Group(){MNUNM="C87.GLSCBDGR     "},
new Group(){MNUNM="C87.GLSUBRP6     "},
new Group(){MNUNM="C84.GLSTMSLS     "},
new Group(){MNUNM="C88.GLCLIAG2     "},
new Group(){MNUNM="C4.GLCSHREC      "},
new Group(){MNUNM="C4.GLCHQREC      "},
new Group(){MNUNM="C4.GLCSHPAY      "},
new Group(){MNUNM="C4.GLCHQPAY      "},
new Group(){MNUNM="C88.GLGRPAGA     "},
new Group(){MNUNM="C4.GLLMTMNT      "},
new Group(){MNUNM="C7.GLLMTQRY      "},
new Group(){MNUNM="C42.GLBNKAD0     "},
new Group(){MNUNM="C82.GLPSTRCV     "},
new Group(){MNUNM="C82.GLPSTPYV     "},
new Group(){MNUNM="C88.GLCOLBRN     "},
new Group(){MNUNM="C89.GLSUPAG2     "},
new Group(){MNUNM="C84.GLSTMCMP     "},
new Group(){MNUNM="C88.GLCLAGE2     "},
new Group(){MNUNM="C3.GLDSCMNT      "},
new Group(){MNUNM="C86.GLCSHFLW     "},
new Group(){MNUNM="C7.GLMODQRY      "},
new Group(){MNUNM="C86.GLSTMCNF     "},
new Group(){MNUNM="C89.GLSTMCNF     "},
new Group(){MNUNM="C84.GLSTMYER     "},
new Group(){MNUNM="C34.GLSLCDYS     "},
new Group(){MNUNM="C88.GLSLCMDY     "},
new Group(){MNUNM="C4.GLPAYOR2      "},
new Group(){MNUNM="C4.PLPAYACP      "},
new Group(){MNUNM="C3.GLBNFMNT      "},
new Group(){MNUNM="C82.GLORDJRA     "},
new Group(){MNUNM="C8a.GLJRMLST     "},
new Group(){MNUNM="C7.GLCSTEML      "},
new Group(){MNUNM="C4.GLCTRMNT      "},
new Group(){MNUNM="C88.GLCL2STM     "},
new Group(){MNUNM="C8A.GLAPRLST     "},
new Group(){MNUNM="C88.GLINVANR     "},
new Group(){MNUNM="C88.GLCOLSAL     "},
new Group(){MNUNM="C82.GLRECPS2     "},
new Group(){MNUNM="C82.GLPAYPS2     "},
new Group(){MNUNM="C3.GLTRTMNT      "},
new Group(){MNUNM="C3.GLACCMNG      "},
new Group(){MNUNM="C86.GLBNKTRA     "},
new Group(){MNUNM="C88.GLCLIRP3     "},
new Group(){MNUNM="C89.GLSUPRP3     "},
new Group(){MNUNM="C88.GLCTRNRP     "},
new Group(){MNUNM="C89.GLSTRNRP     "},
new Group(){MNUNM="C4.GLRECORD      "},
new Group(){MNUNM="C4.GLPAYORD      "},
new Group(){MNUNM="C7.GLPYOQRY      "},
new Group(){MNUNM="C7.GLRPOQRY      "},
new Group(){MNUNM="C6.GLEXLMNT      "},
new Group(){MNUNM="C86.GLCLSR2      "},
new Group(){MNUNM="C6.GLSLCDTR      "},
new Group(){MNUNM="C87.GLCSTRP6     "},
new Group(){MNUNM="C89.GLGRSAGA     "},
new Group(){MNUNM="C4.PLPAYCNF      "},
new Group(){MNUNM="C8.C8A           "},
new Group(){MNUNM="C8A.GLJRMLST     "},
new Group(){MNUNM="C8A.GLJRNLST     "},
new Group(){MNUNM="C6.GLTRNAPR      "},
new Group(){MNUNM="C6.GLTRNUAP      "},
new Group(){MNUNM="C84.GLSTMCLS     "},
new Group(){MNUNM="C84.GLSTMWLD     "},
new Group(){MNUNM="C6.GLBNKDEL      "},
new Group(){MNUNM="C4.GLACCRMK      "},
new Group(){MNUNM="C85.GLBLDL3      "},
new Group(){MNUNM="C84.GLSTMRPC     "},
new Group(){MNUNM="C6.GLBNKCOM      "},
new Group(){MNUNM="C42.GLBNKADF     "},
new Group(){MNUNM="C42.GLBNKIMP     "},
new Group(){MNUNM="C42.GLBNKAD2     "},
new Group(){MNUNM="C3.GLSCCMN2      "},
new Group(){MNUNM="C87.GLCSTRP7     "},
            };
        }
    }
    public class Group
    {
        public string MNUNM { get; set; } //contains "MM.C1" or "MM.C2" and so on
        public string FRMNM { get; set; }
        public string DSCRE { get; set; }
        public string DSCRA { get; set; }
        public string ORGORD { get; set; }
        [JsonIgnore]
        public string ID { get; set; }
        [JsonIgnore]

        public string? ParentID { get; set; }

        public List<Group> Children { get; set; }

    }

    public static class GroupEnumerable
    {
        public static IList<Group> BuildTree(this IEnumerable<Group> source)
        {
            var groups = source.GroupBy(i => i.ParentID);

            var roots = groups.FirstOrDefault(g => g.Key != null).ToList();

            if (roots.Count > 0)
            {
                var dict = groups?.Where(g => !string.IsNullOrEmpty(g?.Key))
                    ?.ToDictionary(g => g.Key, g => g.ToList());
                for (int i = 0; i < roots.Count; i++)
                    AddChildren(roots[i], dict);
            }

            return roots;
        }

        private static void AddChildren(Group node, IDictionary<string, List<Group>> source)
        {
            if (source.ContainsKey(node.ID))
            {
                node.Children = source[node.ID];
                node.Children = node.Children.OrderBy(c => c.MNUNM).ToList();
                for (int i = 0; i < node.Children.Count; i++)
                {
                    AddChildren(node.Children[i], source);
                }
            }
            else
            {
                node.Children = new List<Group>();
            }
        }
    }
    public class UpperCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) =>
            name.ToUpper();
    }
}
