import numpy as np
import matplotlib.pyplot as plt
import DeepModel_Utilities as uDeep
import threading


trainsize = 53450
testsize = 8450
filename1 = 'dataset_norm.csv'

trainset, testset = uDeep.load_dataset(trainsize,testsize, filename1)
train_X, train_Y, test_X, test_Y = uDeep.format_Data(trainset, testset)


"""
Set parameters for the Deep Neural Network
"""
layers_dims = [train_X.shape[0], 4, 8, 4, 8, 4, 8, 4, 8, 1]
beta = 0.9
learning_rate = 0.001
mini_batch_size = 50
num_epochs = 10000
lambd = 0.01
cost_method = "MSE"
gradient_method = "GD"
calibration = None
"""
"""

parameters_GD, cost_GD, cost_GDi = uDeep.NN_model(train_X, train_Y, layers_dims, learning_rate, mini_batch_size, beta, num_epochs, lambd, cost_method, calibration, optimizer = "gd")
parameters_MTM, cost_MTM, cost_MTMi = uDeep.NN_model(train_X, train_Y, layers_dims, learning_rate, mini_batch_size, beta, num_epochs, lambd, cost_method, calibration, optimizer = "momentum")
parameters_ADM, cost_ADM, cost_ADMi = uDeep.NN_model(train_X, train_Y, layers_dims, learning_rate, mini_batch_size, beta, num_epochs, lambd, cost_method, calibration, optimizer = "adam")

"""
Make predictions with the parameters learned with each optimazation algorithm
"""
yhat_GD, caches_GD, errs_GD = uDeep.predict(test_X, test_Y, parameters_GD)
yhat_MTM, caches_MTM, errs_MTM = uDeep.predict(test_X, test_Y, parameters_MTM)
yhat_ADM, caches_ADM, errs_ADM = uDeep.predict(test_X, test_Y, parameters_ADM)
"""
-------------------------------------------------------------------------------
"""
"""
Data was normalized in order to input it inside the NN, it needs to be denormalized
"""
#maxnum_data =162.9057861
maxnum_data =96.78427641

yhat_GD_dN = yhat_GD[0] * maxnum_data
yhat_MTM_dN = yhat_MTM[0] * maxnum_data
yhat_ADM_dN = yhat_ADM[0] * maxnum_data
test_y_dN = test_Y * maxnum_data
"""
-------------------------------------------------------------------------------
"""

"""
Stack data to make all variables the same size
"""
train_X_stack = test_X[[0,1],:]
test_x_Out_Stack = np.sum((train_X_stack * maxnum_data), axis = 0)
"""
-------------------------------------------------------------------------------
"""

"""
Select data for plotting
"""
datasize = 700

plot_yhat_GD = uDeep.selectData(yhat_GD_dN, datasize)
plot_yhat_MTM = uDeep.selectData(yhat_MTM_dN, datasize)
plot_yhat_ADM = uDeep.selectData(yhat_ADM_dN, datasize)
plot_xtest = uDeep.selectData(test_x_Out_Stack, datasize)
plot_trueYtest = uDeep.selectData(test_y_dN, datasize)
samples = list(range(datasize))
"""
"""

plt.plot(samples, plot_yhat_GD, c = 'k', label = 'GD')
plt.plot(samples, plot_yhat_ADM, c = 'm', label = 'ADM')
plt.plot(samples, plot_yhat_MTM, c = 'c', label = 'MTM')
plt.plot(samples, plot_xtest, c = 'r', label = 'raw data')
plt.plot(samples, plot_trueYtest, 'r--', c = 'y', label = 'true value')
plt.xlabel('Samples')
plt.ylabel('Acceleration m/s**2')
plt.title('Fitting curves\n' + 'Learning Rate: ' +str(learning_rate))
plt.legend()
plt.figure(figsize=(80,80))
plt.show()

plt.scatter(samples, plot_yhat_GD, c = 'k', label = 'GD')
plt.scatter(samples, plot_yhat_ADM, c = 'm', label = 'ADM')
plt.scatter(samples, plot_yhat_MTM, c = 'c', label = 'MTM')
plt.scatter(samples, plot_xtest, c = 'r', label = 'raw data')
plt.scatter(samples, plot_trueYtest, c = 'y', label = 'true value')
plt.xlabel('Samples')
plt.ylabel('Acceleration m/s**2')
plt.title('Fitting curves\n' + 'Learning Rate: ' + str(learning_rate))
plt.legend()
plt.figure(figsize=(20,20))
plt.show()


filename2 = 'dataset_norm_3.csv'
trainsize_2 = 2200
testsize_2 = 8
trainset_2, testset_2 = uDeep.load_dataset(trainsize_2,testsize_2, filename2)
train_X_2, train_Y_2, test_X_2, test_Y_2 = uDeep.format_Data(trainset_2, testset_2)

yhat_GD_0, caches_GD_0, errs_GD_0 = uDeep.predict(train_X_2, train_Y_2, parameters_GD)
yhat_MTM_0, caches_MTM_0, errs_MTM_0 = uDeep.predict(train_X_2, train_Y_2, parameters_MTM)
yhat_ADM_0, caches_ADM_0, errs_ADM_0 = uDeep.predict(train_X_2, train_Y_2, parameters_ADM)

maxnum_data = 1

yhat_GD_dN_0 = yhat_GD_0[0] * maxnum_data
yhat_MTM_dN_0 = yhat_MTM_0[0] * maxnum_data
yhat_ADM_dN_0 = yhat_ADM_0[0] * maxnum_data
test_y_dN_0 = train_Y_2 * maxnum_data


train_X2_stack = train_X_2[[0,1],:]
test_x_Out_Stack_0 = np.sum((train_X2_stack * maxnum_data), axis = 0)


plot_yhat_GD_0 = uDeep.selectData(yhat_GD_dN_0, datasize)
plot_yhat_MTM_0 = uDeep.selectData(yhat_MTM_dN_0, datasize)
plot_yhat_ADM_0 = uDeep.selectData(yhat_ADM_dN_0, datasize)
plot_xtest_0 = uDeep.selectData(test_x_Out_Stack_0, datasize)
plot_trueYtest_0 = uDeep.selectData(test_y_dN_0, datasize)

#plt.plot(samples, plot_yhat_GD_0, c = 'k', label = 'GD')
plt.plot(samples, plot_yhat_ADM_0, c = 'm', label = 'ADM')
#plt.plot(samples, plot_yhat_MTM_0, c = 'c', label = 'MTM')
plt.plot(samples, plot_xtest_0, c = 'r', label = 'raw data')
plt.plot(samples, plot_trueYtest_0, 'r--', c = 'y', label = 'true value')
plt.xlabel('Samples')
plt.ylabel('Acceleration m/s**2')
plt.title('Fitting curves\n' + 'Learning Rate: ' +str(learning_rate))
plt.legend()
plt.figure(figsize=(20,20))
plt.show()

