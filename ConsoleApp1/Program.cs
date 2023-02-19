//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text.Json;

//class Program
//{
//    private static void Main()
//    {
        

//        var tree = new TreeBuilder(GetData()).Build();
//        var json = JsonSerializer.Serialize(tree,
//                                            new JsonSerializerOptions
//                                            {
//                                                WriteIndented = true,
//                                                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
//                                            });
//        Console.WriteLine(json);
//    }
//    static List<GNACCESSView> GetData()
//    {
//        var list2 = new List<GNACCESSView>(){
//  new GNACCESSView(){MNUNM="MM.C1"    ,DSCRA="any data1",DSCRE="any data1",FRMNM="any data1",ORGORD="any data1"},
//  new GNACCESSView(){MNUNM="MM.C2"    ,DSCRA="any data2",DSCRE="any data2",FRMNM="any data2",ORGORD="any data2"},
//  new GNACCESSView(){MNUNM="MM.C3"    ,DSCRA="any data3",DSCRE="any data3",FRMNM="any data3",ORGORD="any data3"},
//  new GNACCESSView(){MNUNM="C3.C32"   ,DSCRA="any data4",DSCRE="any data4",FRMNM="any data4",ORGORD="any data4"},
//  new GNACCESSView(){MNUNM="C32.C321" ,DSCRA="any data5",DSCRE="any data5",FRMNM="any data5",ORGORD="any data5"},
//};
//        return list2;
//    }
//}

//public class Node
//{
//    public GNACCESSView Parent { get; set; }
//    public List<Node> Children { get; set; }
//}

//public class TreeBuilder
//{
//    private readonly IReadOnlyCollection<GNACCESSView> _data;

//    private ILookup<GNACCESSView, Node> _parentsAndChildren = null!;

//    public TreeBuilder(IReadOnlyCollection<GNACCESSView> data)
//    {
//        _data = data;
//    }

//    public Node Build()
//    {
//        _parentsAndChildren = _data.ToLookup(GetParent, GetChild);
//        var root = _parentsAndChildren.Select(x => x.Key)                           // get all parents
//                  .Except(_parentsAndChildren.Select(x => x.Key)) // remove parents that are also children
//                                      .First();                                       // there should be only one remaining

//        return BuildNode(root); // call the recursive function
//    }

//    private Node BuildNode(GNACCESSView parent)
//    {
//        return new Node
//        {
//            Parent = parent,
//            Children = _parentsAndChildren[parent].Select(c=>BuildNode(c.Parent)).ToList()
//        };
//    }

//    private static GNACCESSView GetParent(GNACCESSView data)
//    {
//        //var dotIndex = data.MNUNM.IndexOf('.');//MM.C1
//        //data.MNUNM=data.MNUNM.Substring(0, dotIndex);//MM
//        return data; 
//    }

//    private static Node GetChild(GNACCESSView data)
//    {
//        //var dotIndex = data.MNUNM.IndexOf('.');//2
//        //data.MNUNM= data.MNUNM.Substring(dotIndex + 1);//C1
//        return new Node() {Parent=data};
//    }
//}

//public class GNACCESSView
//{
//    public string MNUNM { get; set; }//Key
//    public string FRMNM { get; set; }
//    public string DSCRE { get; set; }
//    public string DSCRA { get; set; }
//    public string ORGORD { get; set; }
//}