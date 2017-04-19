using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamProject.Models;
using System.Xml.XPath;
namespace ExamProject.Helper
{
    public class RssHelper
    {
        public static List<Item> read(string url)
        {
            List<Item> listItem = new List<Item>();
           
            try
            {
                XPathDocument doc = new XPathDocument(url);
                XPathNavigator navigator = doc.CreateNavigator();
                XPathNodeIterator nodes = navigator.Select("//item");
                int i = 0;
                while(nodes.MoveNext()){
                    XPathNavigator node = nodes.Current;
                    if(i<5){
                    listItem.Add(new Item { ID=i,
                                            Title=node.SelectSingleNode("title").Value,
                                           Description = node.SelectSingleNode("description").Value
                    });
                   
                    i++;
                    }
                  
                }
            }
            catch
            {
                listItem = null;
            }
            return listItem;
        }
    }
}