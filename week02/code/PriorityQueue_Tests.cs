using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities (1, 3, 2) and remove one item.
    // Expected Result: The item with the highest priority (3) should be removed first.
    // Defect(s) Found: Initially the code did not properly identify the highest priority 
    // item and did not remove it from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Add three items with the same priority and remove one item.
    // Expected Result: The item closest to the front of the queue (first inserted)
    // should be removed first following FIFO order.
    // Defect(s) Found: The original code used >= which caused later items with the same
    // priority to replace earlier ones, breaking FIFO behavior.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Attempt to dequeue when the queue is empty.
    // Expected Result: An InvalidOperationException should be thrown with the message
    // "The queue is empty."
    // Defect(s) Found: Ensures the queue properly handles empty conditions.
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }
}