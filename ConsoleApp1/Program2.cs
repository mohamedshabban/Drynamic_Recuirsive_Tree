//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.Json;

//class Program2
//{
//    private static void Main()
//    {
//        var data = new List<string> {
//            "MM.C1", "MM.C2", "MM.C3", "C3.C31", "C3.C32", "C32.C321","MM.C4","C4.C41","C4.C42"
//        };
//        var list = new List<GNACCESSView>(){
//            new GNACCESSView(){MNUNM="MM.C1",DSCRA="MM.C1",DSCRE="MM.C1",FRMNM="MM.C1",ORGORD="MM.C1"},
//            new GNACCESSView(){MNUNM="MM.C2",DSCRA="MM.C2",DSCRE="MM.C2",FRMNM="MM.C2",ORGORD="MM.C2"},
//            new GNACCESSView(){MNUNM="MM.C3",DSCRA="C3.C31",DSCRE="C3.C31",FRMNM="C3.C31",ORGORD="C3.C31"},
//            new GNACCESSView(){MNUNM="C3.C32",DSCRA="C3.C32",DSCRE="C3.C32",FRMNM="C3.C32",ORGORD="C3.C32"},
//            new GNACCESSView(){MNUNM="C32.C321",DSCRA="C32.C321",DSCRE="C32.C321",FRMNM="C32.C321",ORGORD="C32.C321"},
//        };
//        var tree = new TreeBuilder(list).Build();
//        var json = JsonSerializer.Serialize(tree,
//                                            new JsonSerializerOptions
//                                            {
//                                                WriteIndented = true,
//                                                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
//                                            });
//        Console.WriteLine(json);
//    }
//}

//public class Node
//{
//    public GNACCESSView Parent { get; set; }
//    public List<Node> Children { get; set; }
//}
//public class GNACCESSView
//{
//    public string MNUNM { get; set; }
//    public string FRMNM { get; set; }
//    public string DSCRE { get; set; }
//    public string DSCRA { get; set; }
//    public string ORGORD { get; set; }
//}


//public class TreeBuilder
//{
//    private readonly IReadOnlyCollection<GNACCESSView> _data;

//    public TreeBuilder(IReadOnlyCollection<GNACCESSView> data)
//    {
//        _data = data;
//    }

//    public Node Build()
//    {
//        var parent = _data[0]

//        return BuildNode(parent); // call the recursive function
//    }

//    private Node BuildNode(GNACCESSView parent)
//    {
//        var parentBeginning = parent.MNUNM + '.';
//        var children = _data
//                       .Where(x => x.MNUNM.StartsWith(parentBeginning)) // get elements that begin with the current parent
//                       .Select(GetChild) // get the children of the current parent
//                       .Select(x => x.ToString())
//                       .Select(BuildNode) // use the children as new parents recursively
//                       .ToList();
//        return new Node
//        {
//            Parent = parent,
//            Children = children
//        };
//    }

//    private static GNACCESSView GetParent(GNACCESSView data)
//    {
//        var dotIndex = data.MNUNM.IndexOf('.');

//        GNACCESSView newData = new GNACCESSView()
//        {
//            MNUNM = data.MNUNM,
//            FRMNM = data.FRMNM,
//            DSCRE = data.DSCRE,
//        }
//        return newData;
//    }

//    private static GNACCESSView GetChild(GNACCESSView data)
//    {
//        var dotIndex = data.MNUNM.IndexOf('.');
//        data.MNUNM = data.MNUNM.AsMemory().Slice(dotIndex + 1).ToString();

//        GNACCESSView newData = new GNACCESSView()
//        {
//            MNUNM = data.MNUNM,
//            FRMNM = data.FRMNM,
//            DSCRE = data.DSCRE,
//        }
//        return newData;
//    }
//}
