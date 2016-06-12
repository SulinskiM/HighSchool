using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Graph
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GraphOfFunction GraphFunction;
        Save save;
        public MainWindow()
        {
            InitializeComponent();
            Ruler.DrawNet(canvas);
            Ruler.DrawCartesian(canvas);
            GraphFunction = new LineFunction();
            GraphFunction.DrawGraph(canvas, 1);
            save = new Save();
        }

        //TODO: Transform graph function
        private void AbsFunction_Click(object sender, RoutedEventArgs e)
        {
            GraphFunction.AbsoluteValueFunction();
            GraphFunction.DrawGraph(canvas, 6);
            SetUp(FunctionPattern, GraphFunction.ToString());
        }

        private void VectorButton_Click(object sender, RoutedEventArgs e)
        {
            Vector vector = LoadVector(TextBoxVectorX, TextBoxVectorY, Error);
            vector.X *= -1;
            GraphFunction.ActualVector.Add(vector);
            GraphFunction.TransformAboutVector(vector);
            GraphFunction.DrawGraph(canvas, 5);
            SetUp(FunctionPattern, GraphFunction.ToString());
            SetUp($" -> Vector[{vector.X}, {vector.Y}]", Transform);
        }

        private void SymXButton_Click(object sender, RoutedEventArgs e)
        {
            GraphFunction.SymmetryOX();
            GraphFunction.DrawGraph(canvas, 4);
            SetUp(FunctionPattern, GraphFunction.ToString());
            SetUp("-> S axis X", Transform);
        }

        private void SymYButton_Click(object sender, RoutedEventArgs e)
        {
            GraphFunction.SymmetryOY();
            GraphFunction.DrawGraph(canvas, 3);
            SetUp(FunctionPattern, GraphFunction.ToString());
            SetUp("-> S axis Y", Transform);
        }

        private void SymZeroButton_Click(object sender, RoutedEventArgs e)
        {
            GraphFunction.SymmetryPointZero();
            GraphFunction.DrawGraph(canvas, 2);
            SetUp(FunctionPattern, GraphFunction.ToString());
            SetUp("-> S point zero", Transform);
        }

        private void AbsArgumentButton_Click(object sender, RoutedEventArgs e)
        {
            GraphFunction.AbsoluteValueArgument();
            GraphFunction.DrawGraph(canvas, 1);
            SetUp(FunctionPattern, GraphFunction.ToString());
            SetUp("-> f(|x|)", Transform);
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            GraphFunction.PowerFunction(LoadPower(TextBoxPower, Error));
            GraphFunction.DrawGraph(canvas, 1);
            SetUp(FunctionPattern, GraphFunction.ToString());
            SetUp("-> k*f(x)", Transform);
        }

        //TODO: Load data from user
        private double LoadPower(TextBox power, TextBlock error)
        {
            try
            {
                SetUp(Error, "");
                if (Convert.ToDouble(power.Text) != 0)
                    return Convert.ToDouble(power.Text);
                else
                    throw new FunctionError("K cant't equel to zero!");
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
                return 1;
            }
            finally
            {
                SetUp(TextBoxPower, "0");
            }
        }

        private Vector LoadVector(TextBox x, TextBox y, TextBlock error)
        {
            try
            {
                SetUp(Error, "");
                Vector vector = new Vector();
                vector.X = int.Parse(x.Text) * 10;
                vector.Y = int.Parse(y.Text) * 10;
                return vector;
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
                Vector vector;
                return vector = new Vector(0, 0);
            }
            finally
            {
                SetUp(x, y, "0");
            }
        }
        private PropertiesLineFunction LoadProperties(TextBox a, TextBox b)
        {
            try
            {
                SetUp(Error, "");
                return new PropertiesLineFunction(double.Parse(a.Text), double.Parse(b.Text) * 10);
            }
            catch(FormatException ex)
            {
                Error.Text = ex.Message;
                return new PropertiesLineFunction(1, 0);
            }   
        }
        private PropertiesQuadraticFunction LoadPropertiesQuadratic(TextBox a, TextBox b, TextBox c)
        {
            try
            {
                SetUp(Error, "");
                return new PropertiesQuadraticFunction(double.Parse(a.Text), double.Parse(b.Text), double.Parse(c.Text));
            }
            catch(FormatException ex)
            {
                Error.Text = ex.Message;
                return new PropertiesQuadraticFunction(1, 0, 0);
            }
        }
        private void SetUp(TextBox x, TextBox y, String value)
        {
            x.Text = value;
            y.Text = value;
        }
        private void SetUp(TextBox x, String value)
        {
            x.Text = value;
        }
        private void SetUp(TextBlock text, String value)
        {
            text.Text = value;
        }
        private void SetUp(String value, TextBlock text)
        {
            text.Text += value;
        }

        //TODO: Modul show position mouse
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            ShowPositionMouse(e);
        }

        private void ShowPositionMouse(MouseEventArgs e)
        {
            try
            {
                Point mouseLocation = e.GetPosition(canvas);

                MousePositionX.Text = Convert.ToString(Math.Round(mouseLocation.X / 10, 1));
                MousePositionY.Text = Convert.ToString(-Math.Round(mouseLocation.Y / 10, 1));
            }
            catch (Exception ex)
            {
                Error.Text = ex.Message;
            }
        }

        private void MainGrid_MouseMove(object sender, MouseEventArgs e)
        {
            MousePositionX.Text = "###";
            MousePositionY.Text = "###";
        }

        //TODO: Draw graph function
        private void LineDrawButton_Click(object sender, RoutedEventArgs e)
        {
            GraphFunction = new LineFunction(LoadProperties(PropLineFunctionA, PropLineFunctionB));
            GraphFunction.DrawGraph(canvas, 1);
            SetUp(FunctionPattern, GraphFunction.ToString());
            SetUp(Transform, "f(x) = x");
        }

        private void QuadraticDrawButton_Click(object sender, RoutedEventArgs e)
        {
            GraphFunction = new QuadraticFunction(LoadPropertiesQuadratic(PropQuadraticFunctionA, PropQuadraticFunctionB, PropQuadraticFunctionC));
            GraphFunction.DrawGraph(canvas, 1);
            SetUp(FunctionPattern, GraphFunction.ToString());
            SetUp(Transform, "f(x) = x*x");
        }

        private void RootDrawButton_Click(object sender, RoutedEventArgs e)
        {
            GraphFunction = new RootFunction();
            GraphFunction.DrawGraph(canvas, 1);
            SetUp(FunctionPattern, GraphFunction.ToString());
            SetUp(Transform, "f(x) = Sqrt(x)");
        }

        private void ActualDrawButton_Click(object sender, RoutedEventArgs e)
        {
            GraphFunction.DrawGraph(canvas, 0);
            SetUp(FunctionPattern, GraphFunction.ToString());
        }

        private void CubicDrawButton_Click(object sender, RoutedEventArgs e)
        {
            GraphFunction = new CubicFunction();
            GraphFunction.DrawGraph(canvas, 0);
            SetUp(FunctionPattern, GraphFunction.ToString());
            SetUp(Transform, "f(x) = x*x*x");
            SetUp(Transform, "f( x )");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            Ruler.DrawNet(canvas);
            Ruler.DrawCartesian(canvas);
        }
        private void ShowValueButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValueForX.Text = Convert.ToString(GraphFunction.Value[(int)((Convert.ToDouble(ArgumerntX.Text)) + 1000)].Y);
            }
            catch(FormatException ex)
            {
                Error.Text = ex.Message;
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (save.whichSaves < save.howMuchSaves)
                save.whichSaves++;
            MuchSaves.Content = save.whichSaves + "/" + save.howMuchSaves;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (save.whichSaves > 1)
                save.whichSaves--;
            MuchSaves.Content = save.whichSaves + "/" + save.howMuchSaves;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            save.SaveGraph(GraphFunction);
            MuchSaves.Content = save.whichSaves + "/" + save.howMuchSaves;
        }

        private void DrawSave_Click(object sender, RoutedEventArgs e)
        {
            GraphFunction = save.ReturnSave();
            GraphFunction.DrawGraph(canvas, 1);
            SetUp(FunctionPattern, GraphFunction.ToString());
        }
    }
}
