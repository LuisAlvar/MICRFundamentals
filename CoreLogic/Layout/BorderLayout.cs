using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoreLogic.Layout
{
    public class BorderLayout
    {
        private int ScreenResolutionWidth { get; set; }
        private int ScreenResolutionHeight { get; set; }
        private double ScreenSize { get; set; }

        /// <summary>
        /// The physical width of the requried form size
        /// </summary>
        private double FormWidth{ get; set; }

        /// <summary>
        /// The physical height of the required form size
        /// </summary>
        private double FormHeight { get; set; }

        /// <summary>
        /// Conversion factor 
        /// </summary>
        private const double MillimetersInch = 25.4;

        /// <summary>
        /// The MCIR Clear Area margin; distance for the bottom.
        /// </summary>
        public const double MCIRClearArea = 16.0;

        /// <summary>
        /// The left edge margin; distance for left side
        /// </summary>
        public const double MCIRLeftMargin = 3.5;

        /// <summary>
        /// The right edge margin; distance from the right side
        /// </summary>
        public const double MCIRRightMargin = 7.6;

        /// <summary>
        /// The right edge margin can have a buffer of +- 1.6 millimeters; distance from the right side
        /// </summary>
        public const double MCIRRightMarginBuffer = 1.6; 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width">Provide the width resolution of your primary screen</param>
        /// <param name="height">Provide the height resolution of your primary screen</param>
        /// <param name="screensize">Provide the diagional screen size of your primary screen</param>
        /// <param name="FormWidth">Provide the desire form width</param>
        /// <param name="FormHeight">Provide the desire form height</param>
        public BorderLayout(int width, int height, double screensize, double formwidth, double formheight) {
            ScreenResolutionWidth = width;
            ScreenResolutionHeight = height;
            this.FormWidth = formwidth;
            this.FormHeight = formheight;
            this.ScreenSize = screensize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double CalculatePPI()
        {
            return Math.Sqrt( Math.Pow(ScreenResolutionWidth, 2) + Math.Pow(ScreenResolutionHeight, 2) ) / ScreenSize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double CalcualtePPM()
        {
            return CalculatePPI() * (1/MillimetersInch);
        }

        /// <summary>
        /// Returns the intended x axis value.
        /// </summary>
        /// <returns></returns>
        public double CalculateLeftMargin()
        {
            return MCIRLeftMargin * CalcualtePPM();
        }

        /// <summary>
        /// Returns the intended x axis value.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public double CalcualteRightMargin(double buffer = 0)
        {
            if (buffer <= MCIRRightMarginBuffer)
            {
                return (FormWidth * CalcualtePPM()) - ((MCIRRightMargin + buffer) * CalcualtePPM());
            }
            return (FormWidth * CalcualtePPM()) - (MCIRRightMargin * CalcualtePPM());
        }

        /// <summary>
        /// Returns the intended Y axis value
        /// </summary>
        /// <returns></returns>
        public double CalculateClearAreaMargin()
        {
            return (FormHeight * CalcualtePPM()) - (MCIRClearArea * CalcualtePPM());
        }

         

        public List<CoreLogic.Structures.Point> GetContextPlane()
        {
          CoreLogic.Structures.Point LeftTop = new Structures.Point(CalculateLeftMargin(), 0);
          CoreLogic.Structures.Point RightTop = new Structures.Point(CalcualteRightMargin(), 0);
          CoreLogic.Structures.Point LeftBot = new Structures.Point(0, CalculateClearAreaMargin());
          CoreLogic.Structures.Point RightBot = new Structures.Point(CalcualteRightMargin(), CalculateClearAreaMargin());

          List<CoreLogic.Structures.Point> listPlanePts = new List<Structures.Point>();
          listPlanePts.Add(LeftTop);
          listPlanePts.Add(RightTop);
          listPlanePts.Add(LeftBot);
          listPlanePts.Add(RightBot);
          
          return listPlanePts;
        }

    }
}
