﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using FMUtils.KeyboardHook;

using Newtonsoft.Json;

namespace Rs3Tracker {
    /// <summary>
    /// Interaction logic for Display.xaml
    /// </summary>
    public partial class Display : Window {
        Hook KeyboardHook = new Hook("Globalaction Link");
        List<KeybindClass> keybindClasses = new List<KeybindClass>();
        int imgCounter, allcounter = 0;
        string style = "";
        public List<Keypressed> ListKeypressed = new List<Keypressed>();
        public Stopwatch stopwatch = new Stopwatch();
        public bool control = false;
        public class Keypressed : KeybindClass {
            public double timepressed { get; set; }
        }

        public class KeybindClass {
            public string modifier { get; set; }
            public string key { get; set; }
            public string img { get; set; }
            public string cmtStyle { get; set; }
            public bool duplicate { get; set; }
        }
        public Display(string _style) {
            InitializeComponent();
            KeyboardHook.KeyDownEvent += HookKeyDown;
            //  KeyboardHook.KeyUpEvent += KeyUp;
            List<KeybindClass> keybindClasses2 = JsonConvert.DeserializeObject<List<KeybindClass>>(File.ReadAllText(".\\keybinds.json"));
            style = _style;
            keybindClasses = (from r in keybindClasses2
                              where r.cmtStyle.ToLower() == style.ToLower()
                              select r).ToList();
            stopwatch.Start();
        }

        private void HookKeyDown(KeyboardHookEventArgs e) {
            if (!control) {
                control = true;
                Keypressed keypressed = new Keypressed();
                string path = "";
                BitmapImage bitmap = new BitmapImage();
                string modifier = "";

                if (e.Key.ToString().ToLower().Equals("none")) {
                    control = false;
                    return;
                }

                if (e.isAltPressed)
                    modifier = "ALT";
                else if (e.isCtrlPressed)
                    modifier = "CTRL";
                else if (e.isShiftPressed)
                    modifier = "SHIFT";
                else if (e.isWinPressed)
                    modifier = "WIN";


                var imgDup = (from r in keybindClasses
                              where r.duplicate == true
                              select r).ToList();

                List<KeybindClass> img = new List<KeybindClass>();

                if (imgDup.Count > 0) {
                    img = (from r in imgDup
                           where r.key.ToLower() == e.Key.ToString().ToLower()
                           where r.modifier.ToString().ToLower() == modifier.ToLower()
                           select r).ToList();
                }

                if (img.Count() == 0) {
                    img = (from r in keybindClasses
                           where r.key.ToLower() == e.Key.ToString().ToLower()
                           where r.modifier.ToString().ToLower() == modifier.ToLower()
                           select r).ToList();

                    if (img.Count() == 0) {
                        control = false;
                        return;
                    }
                }

                var comparekey = (from r in ListKeypressed
                                  where r.img == img[0].img
                                  select r).ToList().OrderByDescending(i => i.timepressed).ToList();

                keypressed.modifier = modifier;
                keypressed.key = e.Key.ToString();
                keypressed.img = img[0].img;
                keypressed.cmtStyle = style;
                keypressed.timepressed = stopwatch.Elapsed.TotalMilliseconds;


                double timepassed = 0;
                if (comparekey.Count > 0)
                    timepassed = comparekey[0].timepressed - keypressed.timepressed;

                if (timepassed > -4200 && timepassed != 0 && keypressed.img.Contains("Air_Surge_icon")) {
                    control = false;
                    return;
                }
                if (timepassed > -1800 && timepassed != 0) {
                    control = false;
                    return;
                }


                if (displayImg10.Source != null)
                    if (displayImg10.Source.ToString().Contains(img[0].img)) {
                        control = false;
                        return;
                    }

                if (displayImg9.Source != null)
                    if (displayImg9.Source.ToString().Contains("Air_Surge_icon") && img[0].img.Contains("Air_Surge_icon")) {
                        control = false;
                        return;
                    }

                switch (imgCounter) {
                    case 0:
                        path = AppDomain.CurrentDomain.BaseDirectory;
                        bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(path + "Images/" + img[0].img + ".png");
                        bitmap.EndInit();
                        displayImg10.Source = bitmap;
                        break;
                    case 1:
                        moveImgs(imgCounter);
                        path = AppDomain.CurrentDomain.BaseDirectory;
                        bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(path + "Images/" + img[0].img + ".png");
                        bitmap.EndInit();
                        displayImg10.Source = bitmap;
                        break;
                    case 2:
                        moveImgs(imgCounter);
                        path = AppDomain.CurrentDomain.BaseDirectory;
                        bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(path + "Images/" + img[0].img + ".png");
                        bitmap.EndInit();
                        displayImg10.Source = bitmap;
                        break;
                    case 3:
                        moveImgs(imgCounter);
                        path = AppDomain.CurrentDomain.BaseDirectory;
                        bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(path + "Images/" + img[0].img + ".png");
                        bitmap.EndInit();
                        displayImg10.Source = bitmap;
                        break;
                    case 4:
                        moveImgs(imgCounter);
                        path = AppDomain.CurrentDomain.BaseDirectory;
                        bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(path + "Images/" + img[0].img + ".png");
                        bitmap.EndInit();
                        displayImg10.Source = bitmap;
                        break;
                    case 5:
                        moveImgs(imgCounter);
                        path = AppDomain.CurrentDomain.BaseDirectory;
                        bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(path + "Images/" + img[0].img + ".png");
                        bitmap.EndInit();
                        displayImg10.Source = bitmap;
                        break;
                    case 6:
                        moveImgs(imgCounter);
                        path = AppDomain.CurrentDomain.BaseDirectory;
                        bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(path + "Images/" + img[0].img + ".png");
                        bitmap.EndInit();
                        displayImg10.Source = bitmap;
                        break;
                    case 7:
                        moveImgs(imgCounter);
                        path = AppDomain.CurrentDomain.BaseDirectory;
                        bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(path + "Images/" + img[0].img + ".png");
                        bitmap.EndInit();
                        displayImg10.Source = bitmap;
                        break;
                    case 8:
                        moveImgs(imgCounter);
                        path = AppDomain.CurrentDomain.BaseDirectory;
                        bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(path + "Images/" + img[0].img + ".png");
                        bitmap.EndInit();
                        displayImg10.Source = bitmap;
                        break;
                    case 9:
                        moveImgs(imgCounter);
                        path = AppDomain.CurrentDomain.BaseDirectory;
                        bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(path + "Images/" + img[0].img + ".png");
                        bitmap.EndInit();
                        displayImg10.Source = bitmap;
                        break;
                    default:
                        moveImgs(imgCounter);
                        path = AppDomain.CurrentDomain.BaseDirectory;
                        bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(path + "Images/" + img[0].img + ".png");
                        bitmap.EndInit();
                        displayImg10.Source = bitmap;
                        break;
                }

                if (imgCounter < 9)
                    imgCounter++;

                allcounter++;

                if (comparekey.Count > 1)
                    ListKeypressed.RemoveAt(0);

                ListKeypressed.Add(keypressed);

                control = false;
            }
        }

        private void moveImgs(int counter) {
            switch (counter) {
                case 1:
                    displayImg9.Source = displayImg10.Source;
                    break;
                case 2:
                    displayImg8.Source = displayImg9.Source;
                    displayImg9.Source = displayImg10.Source;
                    break;
                case 3:
                    displayImg7.Source = displayImg8.Source;
                    displayImg8.Source = displayImg9.Source;
                    displayImg9.Source = displayImg10.Source;
                    break;
                case 4:
                    displayImg6.Source = displayImg7.Source;
                    displayImg7.Source = displayImg8.Source;
                    displayImg8.Source = displayImg9.Source;
                    displayImg9.Source = displayImg10.Source;
                    break;
                case 5:
                    displayImg5.Source = displayImg6.Source;
                    displayImg6.Source = displayImg7.Source;
                    displayImg7.Source = displayImg8.Source;
                    displayImg8.Source = displayImg9.Source;
                    displayImg9.Source = displayImg10.Source;
                    break;
                case 6:
                    displayImg4.Source = displayImg5.Source;
                    displayImg5.Source = displayImg6.Source;
                    displayImg6.Source = displayImg7.Source;
                    displayImg7.Source = displayImg8.Source;
                    displayImg8.Source = displayImg9.Source;
                    displayImg9.Source = displayImg10.Source;
                    break;
                case 7:
                    displayImg3.Source = displayImg4.Source;
                    displayImg4.Source = displayImg5.Source;
                    displayImg5.Source = displayImg6.Source;
                    displayImg6.Source = displayImg7.Source;
                    displayImg7.Source = displayImg8.Source;
                    displayImg8.Source = displayImg9.Source;
                    displayImg9.Source = displayImg10.Source;
                    break;
                case 8:
                    displayImg2.Source = displayImg3.Source;
                    displayImg3.Source = displayImg4.Source;
                    displayImg4.Source = displayImg5.Source;
                    displayImg5.Source = displayImg6.Source;
                    displayImg6.Source = displayImg7.Source;
                    displayImg7.Source = displayImg8.Source;
                    displayImg8.Source = displayImg9.Source;
                    displayImg9.Source = displayImg10.Source;
                    break;
                case 9:
                    displayImg1.Source = displayImg2.Source;
                    displayImg2.Source = displayImg3.Source;
                    displayImg3.Source = displayImg4.Source;
                    displayImg4.Source = displayImg5.Source;
                    displayImg5.Source = displayImg6.Source;
                    displayImg6.Source = displayImg7.Source;
                    displayImg7.Source = displayImg8.Source;
                    displayImg8.Source = displayImg9.Source;
                    displayImg9.Source = displayImg10.Source;
                    break;
            }
        }

    }
}