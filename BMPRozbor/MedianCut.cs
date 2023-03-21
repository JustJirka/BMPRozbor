using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BMPRozbor
{
    // Define a pixel class that has red, green and blue properties
    class Pixel
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
       
    }

    // Define a bucket class that holds a list of pixels and can be split by a color channel
    class Bucket
    {
        public List<Pixel> Pixels { get; set; }

        // Find the color channel with the largest range among the pixels
        public string FindLongestDimension()
        {
            // Calculate the min and max values for each channel
            int minRed = Pixels.Min(p => p.Red);
            int maxRed = Pixels.Max(p => p.Red);
            int minGreen = Pixels.Min(p => p.Green);
            int maxGreen = Pixels.Max(p => p.Green);
            int minBlue = Pixels.Min(p => p.Blue);
            int maxBlue = Pixels.Max(p => p.Blue);

            // Find the channel with the largest range
            int redRange = maxRed - minRed;
            int greenRange = maxGreen - minGreen;
            int blueRange = maxBlue - minBlue;

            if (redRange >= greenRange && redRange >= blueRange)
            {
                return "Red";
            }
            else if (greenRange >= redRange && greenRange >= blueRange)
            {
                return "Green";
            }
            else
            {
                return "Blue";
            }
        }

        // Partition the pixels by their values in a given color channel and return two new buckets
        public List<Bucket> SplitByChannel(string channel)
        {

            // Sort the pixels by their values in the given channel
            switch (channel)
            {
                case "Red":
                    Pixels.Sort((p1, p2) => p1.Red.CompareTo(p2.Red));
                    break;
                case "Green":
                    Pixels.Sort((p1, p2) => p1.Green.CompareTo(p2.Green));
                    break;
                case "Blue":
                    Pixels.Sort((p1, p2) => p1.Blue.CompareTo(p2.Blue));
                    break;
            }

            // Find the median index
            int medianIndex = Pixels.Count / 2;

            // Create two new buckets with the pixels before and after the median index
            Bucket lowerBucket = new Bucket();
            lowerBucket.Pixels = Pixels.GetRange(0, medianIndex);

            Bucket upperBucket = new Bucket();
            upperBucket.Pixels = Pixels.GetRange(medianIndex, Pixels.Count - medianIndex);

            // Return a list of two buckets
            return new List<Bucket>() { lowerBucket, upperBucket };
        }

        // Calculate the mean color of the pixels in this bucket
        public Pixel GetMeanColor()
        {

            // Sum up all pixel values for each channel
            double sumRed = 0;
            double sumGreen = 0;
            double sumBlue = 0;

            foreach (Pixel pixel in Pixels)
            {
                sumRed += pixel.Red;
                sumGreen += pixel.Green;
                sumBlue += pixel.Blue;
            }

            // Divide by number of pixels to get average values for each channel 
            double meanRed = sumRed / Pixels.Count;
            double meanGreen = sumGreen / Pixels.Count;
            double meanBlue = sumBlue / Pixels.Count;

            // Round to nearest integer and create a new pixel with these values 
            Pixel meanPixel = new Pixel();
            meanPixel.Red = (int)Math.Round(meanRed);
            meanPixel.Green = (int)Math.Round(meanGreen);
            meanPixel.Blue = (int)Math.Round(meanBlue);

            return meanPixel;

        }
        // Define a function that performs median cut on an array of colors and returns a list of mean colors 
        public static List<Pixel> MedianCut(Pixel[] colors, int numberOfColors)
        {

            // Create an initial bucket with all colors
            Bucket initialBucket = new Bucket();
            initialBucket.Pixels = new List<Pixel>(colors);

            // Create a list of buckets and add the initial bucket to it
            List<Bucket> buckets = new List<Bucket>();
            buckets.Add(initialBucket);

            // Repeat until the number of buckets equals the number of colors
            while (buckets.Count < numberOfColors && buckets[0].Pixels.Count > 2)
            {

                // Find the bucket with the longest dimension
                Bucket longestBucket = null;
                string longestDimension = null;
                int longestRange = 0;

                foreach (Bucket bucket in buckets)
                {
                    string dimension = bucket.FindLongestDimension();
                    int max = 0;
                    int min = 255;

                    foreach (Pixel pixel in bucket.Pixels)
                    {
                        switch (dimension)
                        {
                            case "Red":
                                max = Math.Max(max, pixel.Red);
                                min = Math.Min(min, pixel.Red);
                                break;
                            case "Green":
                                max = Math.Max(max, pixel.Green);
                                min = Math.Min(min, pixel.Green);
                                break;
                            case "Blue":
                                max = Math.Max(max, pixel.Blue);
                                min = Math.Min(min, pixel.Blue);
                                break;
                        }
                    }

                    // Calculate the range
                    int range = max - min;
                    if (range > longestRange)
                    {
                        longestBucket = bucket;
                        longestDimension = dimension;
                        longestRange = range;
                    }
                }

                // Split the longest bucket by its longest dimension and remove it from the list
                List<Bucket> splitBuckets = longestBucket.SplitByChannel(longestDimension);
                buckets.Remove(longestBucket);

                // Add the two new buckets to the list
                buckets.AddRange(splitBuckets);
            }

            // Create a list of mean colors by averaging each bucket
            List<Pixel> meanColors = new List<Pixel>();

            foreach (Bucket bucket in buckets)
            {
                Pixel meanColor = bucket.GetMeanColor();
                meanColors.Add(meanColor);
            }

            // Return the list of mean colors
            return meanColors;

        }
        // Define a method that calculates the weighted average of a list of pixels
        public Pixel WeightedAverage(List<Pixel> pixels)
        {
            // Create a dictionary that maps each pixel value to its frequency
            Dictionary<Pixel, int> frequency = new Dictionary<Pixel, int>();
            // Loop through the pixels and update the frequency dictionary
            foreach (Pixel p in pixels)
            {
                if (frequency.ContainsKey(p))
                {
                    frequency[p]++;
                }
                else
                {
                    frequency.Add(p, 1);
                }
            }

            // Initialize variables for storing the weighted sum and total count
            int redSum = 0;
            int greenSum = 0;
            int blueSum = 0;
            int totalCount = 0;

            // Loop through the frequency dictionary and calculate the weighted sum and total count 
            foreach (KeyValuePair<Pixel, int> pair in frequency)
            {
                Pixel p = pair.Key;
                int f = pair.Value;
                redSum += p.Red * f;
                greenSum += p.Green * f;
                blueSum += p.Blue * f;
                totalCount += f;
            }

            // Calculate the weighted average by dividing the weighted sum by total count 
            Pixel average = new Pixel();
            average.Red = redSum / totalCount;
            average.Green = greenSum / totalCount;
            average.Blue = blueSum / totalCount;

            // Returnthe weighted average pixel 
            return average;
        }
        public static int GetClosestColor(List<Pixel> paleta, Pixel color)
        {
            int closestColor = 0;
            int distance = 256 * 3;
            for (int i = 0; i < paleta.Count; i++)
            {
                Pixel pixel = paleta[i];
                int currentDistance = Math.Abs(pixel.Red - color.Red) + Math.Abs(pixel.Blue - color.Blue) + Math.Abs(pixel.Green - color.Green);
                if (currentDistance < distance)
                {
                    closestColor = i;
                    distance = currentDistance;
                }
            }
            return closestColor;
        }
    }

}
