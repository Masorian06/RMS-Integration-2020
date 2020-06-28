class TimeSeriesData():
    """TimeSeriesData class that will be use for generation the sinusoidal data points"""
    def __init__(self, num_points, xmin, xmax):
        self.xmin = xmin
        self.xmax = xmax
        self.num_points = num_points
        self.resolution = (xmax - xmin) / num_points
        self.x_data = np.linspace(xmin, xmax, num_points)
        self.y_true = np.sin(self.x_data)

    def ret_true(self, x_series):
        return np.sin(x_series)

    def next_batch(self, batch_size, steps, return_batch_ts = False):
        #Ramdomly starting points for batch
        random_start = np.random.rand(batch_size, 1)

        #Introduce ramdom points in the time series
        ts_start = random_start * (self.xmax - self.xmin - (steps * self.resolution)) #Converts any number into a point in the time-series

        batch_ts = ts_start + np.arange(0.0, steps + 1) * self.resolution #Predicts only one step ahead in time

        y_batch = np.sin(batch_ts)

        #Formatting for RNN
        if return_batch_ts:
            return y_batch[:, :-1].reshape(-1, steps, 1), y_batch[:, 1:].reshape(-1, steps, 1), batch_ts
        else:
            return y_batch[:, :1].reshape(-1, steps, 1), y_batch[:, 1:].reshape(-1, steps, 1) #Return the sequence shifted over one time step



