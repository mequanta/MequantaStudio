using System;
using MonoDevelop.Ide.Gui.Components;
using SmartQuant;
using MonoDevelop.DesignerSupport;
using MonoDevelop.Core;
using System.Collections.Generic;

namespace MequantaStudio.SmartQuant
{
    public class PortfolioNode
    {
        public Portfolio Portfolio { get; private set; }

        public List<PortfolioNode> Children { get; private set; }


        public PortfolioNode(Portfolio portfolio)
        {
            Portfolio = portfolio;
            foreach (var p in portfolio.Children)
                Children.Add(new PortfolioNode(p));
        }
    }

    public class PortfolioNodeBuilder : TypeNodeBuilder
    {
        public override string GetNodeName(ITreeNavigator thisNode, object dataObject)
        {
            return ((PortfolioNode)dataObject).Portfolio.Name;
        }

        public override Type NodeDataType
        {
            get
            { 
                return typeof(PortfolioNode);
            }
        }

        public override Type CommandHandlerType
        {
            get
            { 
                return typeof(PortfolioCommandHandler);
            }
        }

        public override string ContextMenuAddinPath
        {
            get
            { 
                return "/MequantaStudio/SmartQuant/ContextMenu/PortfolioPad/PortfolioNode";
            }
        }

        public override bool HasChildNodes(ITreeBuilder builder, object dataObject)
        {
            return true;
        }

        public override void BuildNode(ITreeBuilder treeBuilder, object dataObject, NodeInfo nodeInfo)
        {
            var node = dataObject as PortfolioNode;
            nodeInfo.Label = node.Portfolio.Name;
            nodeInfo.Icon = Context.GetIcon("ms-sq-portfolio");
        }

        public override void BuildChildNodes(ITreeBuilder builder, object dataObject)
        {
            var node = dataObject as PortfolioNode;
            foreach (var portfolio in node.Children)
                builder.AddChild(portfolio);
        }
    }

    public class PortfolioNodePropertyProvider : IPropertyProvider
    {
        public bool SupportsObject(object obj)
        {
            return obj is PortfolioNode;
        }

        public object CreateProvider(object obj)
        {
            return new PortfolioNodeDescriptor((PortfolioNode)obj);
        }
    }

    public class PortfolioNodeDescriptor : CustomDescriptor
    {
        private PortfolioNode portfolioNode;

        public PortfolioNodeDescriptor(PortfolioNode portfolioNode)
        {
            this.portfolioNode = portfolioNode;
        }

        [LocalizedCategory("Misc")]
        [LocalizedDisplayName("Length")]
        public int Length
        {
            get
            {
                return this.portfolioNode.Portfolio.Name.Length;
            }
        }
    }
}

