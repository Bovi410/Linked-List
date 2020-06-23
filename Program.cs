using System;

class LinkedListV2
{
	public class Node
	{
		public int data;
		public Node next;
	};

	static Node push(Node head_ref,
					int new_data)
	{
		Node new_node = new Node();

		new_node.data = new_data;

		new_node.next = head_ref;

		head_ref = new_node;

		return head_ref;
	}

	static void printList(Node head)
	{
		if (head == null)
			return;

		while (head.next != null)
		{
			Console.Write(head.data + " -> ");
			head = head.next;
		}
		Console.WriteLine(head.data);
	}


	Node reverselist(Node node)
	{
		Node prev = null, curr = node, next;
		while (curr != null)
		{
			next = curr.next;
			curr.next = prev;
			prev = curr;
			curr = next;
		}
		node = prev;
		return node;
	}

	void rearrange(Node node)
	{

		Node slow = node, fast = slow.next;
		while (fast != null && fast.next != null)
		{
			slow = slow.next;
			fast = fast.next.next;
		}

		Node node1 = node;
		Node node2 = slow.next;
		slow.next = null;

		node2 = reverselist(node2);

		Node curr = node;
		while (node1 != null || node2 != null)
		{

			if (node1 != null)
			{
				curr.next = node1;
				curr = curr.next;
				node1 = node1.next;
			}

			if (node2 != null)
			{
				curr.next = node2;
				curr = curr.next;
				node2 = node2.next;
			}
		}
 
		node = node.next;
	}

	public static void Main()
	{
		Node head = null;

		Console.WriteLine("Write size for array");
		int n = Convert.ToInt32(Console.ReadLine());
		int a = 0;
		Console.WriteLine("Add List:");
		for (int i = 0; i < n; i++)
		{
			a = Convert.ToInt32(Console.ReadLine());
			head = push(head, a);
		}

		Console.WriteLine("Modified List:");
		printList(head);
	}
}
