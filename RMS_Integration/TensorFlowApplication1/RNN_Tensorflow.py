import numpy as np
import sys
import os
import tensorflow as tf
import pandas as pd
import matplotlib
import matplotlib.pyplot as plt
import random
import shutil
import tensorflow.contrib.learn as tflearn
import tensorflow.contrib.layers as tflayers
from tensorflow.contrib.learn.python.learn import learn_runner
import tensorflow.contrib.metrics as metrics
import tensorflow.contrib.rnn as rnn
###################################################################
# Variables                                                       #
# When launching project or scripts from Visual Studio,           #
# input_dir and output_dir are passed as arguments automatically. #
# Users could set them from the project setting page.             #
###################################################################

FLAGS = tf.app.flags.FLAGS
tf.app.flags.DEFINE_string("input_dir", ".", "Input directory where training dataset and meta data are saved")
tf.app.flags.DEFINE_string("output_dir", ".", "Output directory where output such as logs are saved.")
tf.app.flags.DEFINE_string("log_dir", ".", "Model directory where final model files are saved.")


def main(_):
    # TODO: add your code here
    with tf.Session() as sess:
        welcome = sess.run(tf.constant("Hello, TensorFlow!"))
        print(welcome)
        random.seed(111)
        ts = pd.date_range(start = '2000', periods = 209, freq = 'M')
        ts.plot(c = 'b', title = 'Example Time Series')
        plt.show()
        ts.head(10)
    exit(0)


if __name__ == "__main__":
    tf.app.run()